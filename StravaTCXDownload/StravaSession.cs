using Strava.Activities;
using Strava.Authentication;
using Strava.Clients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace StravaTCXDownload
{
	public class StravaSession
	{
		private string _userName;
		private string _password;
		private string _apiKey;
		private bool _hasInit = false;
		private CookieContainer _cookieHolder;
		private StaticAuthentication _auth;

		public delegate void ProgressDelegate(int numberAcquired);
		private delegate string AttributeFinder(HtmlAgilityPack.HtmlDocument document, string name);

		public StravaSession(string userName, string password, string apiKey)
		{
			this._userName = userName;
			this._password = password;
			this._apiKey = apiKey;
		}

		public string InitSession()
		{
			HttpStatusCode httpStatus;

			// No idea why from time to time the login fails.  It does 
			// not appear that it is a failed login, but instead
			// strava is ignoring the post and is just re-rendering the
			// login page.  - must have something to do with the authenticity token or something.
			var loggedIn = false;
			for (var tryCount = 0; tryCount < 3; tryCount++)
			{
				this._cookieHolder = new CookieContainer();
				var loginPage = this.HttpGet("https://www.strava.com/login", out httpStatus);

				if (httpStatus != HttpStatusCode.OK)
				{
					return "Unable to contact the Strava server.";
				}

				// Attempt to parse the table.
				var loader = new HtmlAgilityPack.HtmlDocument();
				loader.LoadHtml(loginPage);

				AttributeFinder finder = (doc, name) =>
				{
					var element = (from n in doc.DocumentNode.Descendants("input") where n.GetAttributeValue("name", string.Empty) == name select n).FirstOrDefault();

					if (element == null)
						return string.Empty;

					var attb = element.Attributes.FirstOrDefault(f => f.Name == "value");

					if (attb == null)
						return string.Empty;

					return attb.Value;
				};

				var authTok = finder(loader, "authenticity_token");
				var utf8 = finder(loader, "utf8");
				
				var loginResultPage = this.HttpPost(
					"https://www.strava.com/session",
					string.Format(
						"email={0}&password={1}&authenticity_token={2}&utf8=%E2%9C%93",
						HttpUtility.HtmlEncode(this._userName),
						HttpUtility.HtmlEncode(this._password),
						authTok),
					out httpStatus);

				if (httpStatus != HttpStatusCode.OK)
				{
					return "Unable to contact the Strava server.";
				}

				loader = new HtmlAgilityPack.HtmlDocument();
				loader.LoadHtml(loginResultPage);

				var htmlObj = loader.DocumentNode.Descendants("html").FirstOrDefault();

				if (htmlObj == null)
				{
					return "Unexpected result returned from Strava Server";
				}

				if (htmlObj.GetAttributeValue("class", string.Empty).Split(' ').Any(a => a.ToLower() == "logged-in"))
				{
					loggedIn = true;
					break;
				}

				// Not logged in.
				// Need to see if an 'alert-message' exists.
				htmlObj = (from n in loader.DocumentNode.Descendants("div") where n.GetAttributeValue("class", string.Empty) == "alert-message" select n).FirstOrDefault();

				if (htmlObj != null
					&& htmlObj.InnerHtml.ToLower().Contains("did not match"))
				{
					// If this exists, the error is wrong pwd.
					break;
				}

				if (htmlObj!=null
					&& htmlObj.InnerHtml.ToLower().Contains("expired"))
				{
					// Session expired... loop around again.
					// Is this a .net thing?  I'm creating a new cookie container...whatever, I 
					// guess this hack seems to work by looping and just trying again.
				}
			}

			if (!loggedIn)
			{
				return "The login details provider do not appear to be valid.";
			}

			// We're now logged in.

			// Next, we need to be sure we have a valid API token.
			this._auth = new StaticAuthentication(this._apiKey);
			var athlete = new AthleteClient(this._auth);

			try
			{
				var details = athlete.GetAthlete();
				
				if (details == null 
					|| details.Email == null
					|| details.Email.ToLower() != this._userName.ToLower())
				{
					return "The API key is not associated to the same Strava account as the user name provided.";
				}
			}
			catch
			{
				return "The API key provided does not appear to be valid";
			}


			return string.Empty;
		}

		public string GetTCX(long id)
		{
			HttpStatusCode status;
			var raw = this.HttpGet(string.Format("https://www.strava.com/activities/{0}/export_tcx", id), out status);

			if (status == HttpStatusCode.OK)
			{
				return raw;
			}

			return string.Empty;
		}

		public IEnumerable<ActivitySummary> GetAllActivities(ProgressDelegate callback)
		{
			var ac = new ActivityClient(this._auth);
			var finalList = new List<ActivitySummary>();

			var page = 1;
			for (;;)
			{
				var list = ac.GetActivities(page++, 50);
				if (list == null || list.Count == 0) break;

				finalList.AddRange(list);
				if (callback != null)
					callback(finalList.Count);
			}

			return finalList;
		}

		private string HttpPost(string uri, string payload, out HttpStatusCode resultingStatus)
		{
			var request = (HttpWebRequest)WebRequest.Create(uri);
			request.CookieContainer = this._cookieHolder;
			var data = Encoding.ASCII.GetBytes(payload);

			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = data.Length;

			using (var stream = request.GetRequestStream())
			{
				stream.Write(data, 0, data.Length);
			}

			var response = (HttpWebResponse)request.GetResponse();

			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

			resultingStatus = HttpStatusCode.OK;
			return responseString;
		}

		private string HttpGet(string uri, out HttpStatusCode resultingStatus)
		{
			var request = (HttpWebRequest)WebRequest.Create(uri);

			request.CookieContainer = this._cookieHolder;
			request.Method = "GET";
			request.ContentType = "application/x-www-form-urlencoded";

			try
			{
				var response = (HttpWebResponse)request.GetResponse();
				var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

				// By default, a HttpWebRequest object thrown an exception for any other
				// status code other than 200 series/success.
				resultingStatus = response.StatusCode;
				return responseString;
			}
			catch (WebException ex)
			{
				var errResp = ex.Response as HttpWebResponse;
				if (errResp == null)
					resultingStatus = HttpStatusCode.InternalServerError;
				else
					resultingStatus = errResp.StatusCode;

				return string.Empty;
			}
			catch(Exception ex)
			{
				resultingStatus = HttpStatusCode.InternalServerError;
				return string.Empty;
			}

			return string.Empty;
		}
	}
}
