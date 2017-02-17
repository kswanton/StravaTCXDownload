using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StravaTCXDownload
{
	public partial class frmMain : Form
	{
		private StravaSession _session;
		private delegate void ErrorDelegate(string errorMessage);
		private Thread _worker;
		private string _targetDir;
		private bool _abort = false;

		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			this.Height = this.pnlViewLogin.Height + this.pnlViewLogin.Top + (this.Height - this.ClientRectangle.Height);
			this.Width = this.pnlViewLogin.Width + this.pnlViewLogin.Left + (this.Width - this.ClientRectangle.Width);

			this.pnlViewError.Top = this.pnlViewActivityListAquire.Top = this.pnlViewTCXDownload.Top = pnlViewComplete.Top = this.pnlViewLogin.Top;
			this.pnlViewError.Left = this.pnlViewActivityListAquire.Left = this.pnlViewTCXDownload.Left = pnlViewComplete.Left = this.pnlViewLogin.Left;

			this.pnlViewError.Visible = this.pnlViewActivityListAquire.Visible = this.pnlViewTCXDownload.Visible = pnlViewComplete.Visible = false;

			this.CenterToScreen();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			foreach(var fld in new[] { this.txtUserName, this.txtPassword, this.txtAPIKey })
			{
				if (fld.Text.Trim().Length == 0)
				{
					MessageBox.Show("You must enter your username/email, password and API key to continue.");
					return;
				}
			}

			this._session  = new StravaSession(this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim(), this.txtAPIKey.Text.Trim());
			var err = this._session.InitSession();

			if (!string.IsNullOrEmpty(err))
			{
				this.ShowError(err);
				return;
			}

			this._targetDir = Path.Combine(Environment.CurrentDirectory, "activities");

			if (!Directory.Exists(this._targetDir))
			{
				try
				{
					Directory.CreateDirectory(this._targetDir);
				}
				catch(Exception ex)
				{
					this.ShowError(string.Format("Unable to create the directory '{0}', system reported: {1}", this._targetDir, ex.Message));
					return;
				}
			}

			// Login is successful; start the process of aquiring all activities.
			this.lblAquireStatus.Text = "Starting to acquire all activities";
			this.pnlViewLogin.Visible = false;
			this.pnlViewActivityListAquire.Visible = true;

			this._worker = new Thread(this.ActivityAcquire);
			this._worker.Start();
		}

		private void ActivityAcquire()
		{
			var activities = this._session.GetAllActivities((numAcq) =>
			{
				this.SetAcquireCount(numAcq);
			}).ToArray();

			this.SwapView(this.pnlViewTCXDownload);

			this.Invoke((Action)delegate 
			{
				this.pbProgress.Maximum = activities.Count();
				this.pbProgress.Minimum = 0;
				this.pbProgress.Value = 0;
			});

			for (int offset = 0; offset < activities.Length; offset++)
			{
				this.Invoke((Action)delegate
				{
					this.pbProgress.Value = offset + 1;
					this.lblTCXStatus.Text = string.Format("Downloading TCX file {0} of {1}", offset + 1, activities.Length);
				});

				// Check if the file has already been acquired...
				if (Directory.GetFiles(this._targetDir, string.Format("*_{0}.tcx", activities[offset].Id)).Count() == 0)
				{
					// Nope; need to request it.
					var tcx = this._session.GetTCX(activities[offset].Id); 

					if (string.IsNullOrEmpty(tcx))
					{
						this.ShowError("Unable to obtain a TCX file, aborting operation.  Activity ID: " + activities[offset].Id.ToString());
						return;
					}

					var fileName = string.Format("{0:yyyyMMdd}_{1}.tcx", activities[offset].DateTimeStart, activities[offset].Id);

					File.WriteAllText(Path.Combine(this._targetDir, fileName), tcx);
				}

				if (this._abort)
				{
					this.ShowError("Operation aborted");
					return;
				}
			}

			this.SwapView(this.pnlViewComplete);
		}

		private void SwapView(Panel pnl)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action<Panel>(this.SwapView), pnl);
				return;
			}

			this.pnlViewActivityListAquire.Visible = this.pnlViewError.Visible = this.pnlViewLogin.Visible = this.pnlViewTCXDownload.Visible = this.pnlViewComplete.Visible = false;
			pnl.Visible = true;
		}

		private void SetAcquireCount(int cnt)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action<int>(this.SetAcquireCount), cnt);
				return;
			}

			this.lblAquireStatus.Text = string.Format("{0} activity details acquired", cnt);
		}

		private void ShowError(string err)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new ErrorDelegate(this.ShowError), err);
				return;
			}

			this.lblErrorMessage.Text = err;

			this.pnlViewLogin.Visible = this.pnlViewActivityListAquire.Visible = this.pnlViewComplete.Visible = this.pnlViewTCXDownload.Visible = false;
			this.pnlViewError.Visible = true;
		}

		private void btnErrorClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void llblShowFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("explorer.exe", this._targetDir);
		}

		private void btnCompleteClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnTCXAbort_Click(object sender, EventArgs e)
		{
			this._abort = true;
		}
	}
}
