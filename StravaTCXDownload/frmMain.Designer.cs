namespace StravaTCXDownload
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtAPIKey = new System.Windows.Forms.TextBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.pnlViewLogin = new System.Windows.Forms.Panel();
			this.pnlViewError = new System.Windows.Forms.Panel();
			this.lblErrorMessage = new System.Windows.Forms.Label();
			this.btnErrorClose = new System.Windows.Forms.Button();
			this.pnlViewActivityListAquire = new System.Windows.Forms.Panel();
			this.lblAquireStatus = new System.Windows.Forms.Label();
			this.btnAbort = new System.Windows.Forms.Button();
			this.pnlViewTCXDownload = new System.Windows.Forms.Panel();
			this.pbProgress = new System.Windows.Forms.ProgressBar();
			this.lblTCXStatus = new System.Windows.Forms.Label();
			this.btnTCXAbort = new System.Windows.Forms.Button();
			this.pnlViewComplete = new System.Windows.Forms.Panel();
			this.pbCheck = new System.Windows.Forms.PictureBox();
			this.llblShowFolder = new System.Windows.Forms.LinkLabel();
			this.label5 = new System.Windows.Forms.Label();
			this.btnCompleteClose = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pnlViewLogin.SuspendLayout();
			this.pnlViewError.SuspendLayout();
			this.pnlViewActivityListAquire.SuspendLayout();
			this.pnlViewTCXDownload.SuspendLayout();
			this.pnlViewComplete.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbCheck)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Strava User Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Strava Password";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 20);
			this.label3.TabIndex = 3;
			this.label3.Text = "Strava API Key";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(109, 9);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(282, 20);
			this.txtUserName.TabIndex = 4;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(109, 32);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(282, 20);
			this.txtPassword.TabIndex = 5;
			// 
			// txtAPIKey
			// 
			this.txtAPIKey.Location = new System.Drawing.Point(109, 55);
			this.txtAPIKey.Name = "txtAPIKey";
			this.txtAPIKey.Size = new System.Drawing.Size(282, 20);
			this.txtAPIKey.TabIndex = 6;
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(316, 81);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 7;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// pnlViewLogin
			// 
			this.pnlViewLogin.Controls.Add(this.label1);
			this.pnlViewLogin.Controls.Add(this.btnStart);
			this.pnlViewLogin.Controls.Add(this.label2);
			this.pnlViewLogin.Controls.Add(this.txtAPIKey);
			this.pnlViewLogin.Controls.Add(this.label3);
			this.pnlViewLogin.Controls.Add(this.txtPassword);
			this.pnlViewLogin.Controls.Add(this.txtUserName);
			this.pnlViewLogin.Location = new System.Drawing.Point(93, 12);
			this.pnlViewLogin.Name = "pnlViewLogin";
			this.pnlViewLogin.Size = new System.Drawing.Size(405, 115);
			this.pnlViewLogin.TabIndex = 8;
			// 
			// pnlViewError
			// 
			this.pnlViewError.Controls.Add(this.lblErrorMessage);
			this.pnlViewError.Controls.Add(this.btnErrorClose);
			this.pnlViewError.Location = new System.Drawing.Point(93, 133);
			this.pnlViewError.Name = "pnlViewError";
			this.pnlViewError.Size = new System.Drawing.Size(405, 115);
			this.pnlViewError.TabIndex = 9;
			// 
			// lblErrorMessage
			// 
			this.lblErrorMessage.Location = new System.Drawing.Point(13, 36);
			this.lblErrorMessage.Name = "lblErrorMessage";
			this.lblErrorMessage.Size = new System.Drawing.Size(378, 20);
			this.lblErrorMessage.TabIndex = 8;
			this.lblErrorMessage.Text = "###";
			this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnErrorClose
			// 
			this.btnErrorClose.Location = new System.Drawing.Point(316, 81);
			this.btnErrorClose.Name = "btnErrorClose";
			this.btnErrorClose.Size = new System.Drawing.Size(75, 23);
			this.btnErrorClose.TabIndex = 7;
			this.btnErrorClose.Text = "Close";
			this.btnErrorClose.UseVisualStyleBackColor = true;
			this.btnErrorClose.Click += new System.EventHandler(this.btnErrorClose_Click);
			// 
			// pnlViewActivityListAquire
			// 
			this.pnlViewActivityListAquire.Controls.Add(this.lblAquireStatus);
			this.pnlViewActivityListAquire.Controls.Add(this.btnAbort);
			this.pnlViewActivityListAquire.Location = new System.Drawing.Point(93, 254);
			this.pnlViewActivityListAquire.Name = "pnlViewActivityListAquire";
			this.pnlViewActivityListAquire.Size = new System.Drawing.Size(405, 115);
			this.pnlViewActivityListAquire.TabIndex = 10;
			// 
			// lblAquireStatus
			// 
			this.lblAquireStatus.Location = new System.Drawing.Point(13, 36);
			this.lblAquireStatus.Name = "lblAquireStatus";
			this.lblAquireStatus.Size = new System.Drawing.Size(378, 20);
			this.lblAquireStatus.TabIndex = 8;
			this.lblAquireStatus.Text = "###";
			this.lblAquireStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnAbort
			// 
			this.btnAbort.Location = new System.Drawing.Point(316, 81);
			this.btnAbort.Name = "btnAbort";
			this.btnAbort.Size = new System.Drawing.Size(75, 23);
			this.btnAbort.TabIndex = 7;
			this.btnAbort.Text = "Abort";
			this.btnAbort.UseVisualStyleBackColor = true;
			// 
			// pnlViewTCXDownload
			// 
			this.pnlViewTCXDownload.Controls.Add(this.pbProgress);
			this.pnlViewTCXDownload.Controls.Add(this.lblTCXStatus);
			this.pnlViewTCXDownload.Controls.Add(this.btnTCXAbort);
			this.pnlViewTCXDownload.Location = new System.Drawing.Point(93, 375);
			this.pnlViewTCXDownload.Name = "pnlViewTCXDownload";
			this.pnlViewTCXDownload.Size = new System.Drawing.Size(405, 115);
			this.pnlViewTCXDownload.TabIndex = 11;
			// 
			// pbProgress
			// 
			this.pbProgress.Location = new System.Drawing.Point(6, 50);
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.Size = new System.Drawing.Size(396, 23);
			this.pbProgress.TabIndex = 9;
			// 
			// lblTCXStatus
			// 
			this.lblTCXStatus.Location = new System.Drawing.Point(13, 9);
			this.lblTCXStatus.Name = "lblTCXStatus";
			this.lblTCXStatus.Size = new System.Drawing.Size(378, 20);
			this.lblTCXStatus.TabIndex = 8;
			this.lblTCXStatus.Text = "Downloading TCX Files";
			this.lblTCXStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnTCXAbort
			// 
			this.btnTCXAbort.Location = new System.Drawing.Point(316, 81);
			this.btnTCXAbort.Name = "btnTCXAbort";
			this.btnTCXAbort.Size = new System.Drawing.Size(75, 23);
			this.btnTCXAbort.TabIndex = 7;
			this.btnTCXAbort.Text = "Abort";
			this.btnTCXAbort.UseVisualStyleBackColor = true;
			this.btnTCXAbort.Click += new System.EventHandler(this.btnTCXAbort_Click);
			// 
			// pnlViewComplete
			// 
			this.pnlViewComplete.Controls.Add(this.pbCheck);
			this.pnlViewComplete.Controls.Add(this.llblShowFolder);
			this.pnlViewComplete.Controls.Add(this.label5);
			this.pnlViewComplete.Controls.Add(this.btnCompleteClose);
			this.pnlViewComplete.Location = new System.Drawing.Point(93, 496);
			this.pnlViewComplete.Name = "pnlViewComplete";
			this.pnlViewComplete.Size = new System.Drawing.Size(405, 115);
			this.pnlViewComplete.TabIndex = 12;
			// 
			// pbCheck
			// 
			this.pbCheck.Image = global::StravaTCXDownload.Properties.Resources.chk;
			this.pbCheck.Location = new System.Drawing.Point(16, 23);
			this.pbCheck.Name = "pbCheck";
			this.pbCheck.Size = new System.Drawing.Size(60, 56);
			this.pbCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbCheck.TabIndex = 10;
			this.pbCheck.TabStop = false;
			// 
			// llblShowFolder
			// 
			this.llblShowFolder.Location = new System.Drawing.Point(140, 43);
			this.llblShowFolder.Name = "llblShowFolder";
			this.llblShowFolder.Size = new System.Drawing.Size(251, 23);
			this.llblShowFolder.TabIndex = 9;
			this.llblShowFolder.TabStop = true;
			this.llblShowFolder.Text = "Click here to view files";
			this.llblShowFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowFolder_LinkClicked);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(140, 23);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(251, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "All TCX files have been downloaded";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCompleteClose
			// 
			this.btnCompleteClose.Location = new System.Drawing.Point(316, 81);
			this.btnCompleteClose.Name = "btnCompleteClose";
			this.btnCompleteClose.Size = new System.Drawing.Size(75, 23);
			this.btnCompleteClose.TabIndex = 7;
			this.btnCompleteClose.Text = "Close";
			this.btnCompleteClose.UseVisualStyleBackColor = true;
			this.btnCompleteClose.Click += new System.EventHandler(this.btnCompleteClose_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::StravaTCXDownload.Properties.Resources.strava;
			this.pictureBox1.Location = new System.Drawing.Point(18, 18);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(69, 69);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(772, 700);
			this.Controls.Add(this.pnlViewComplete);
			this.Controls.Add(this.pnlViewTCXDownload);
			this.Controls.Add(this.pnlViewActivityListAquire);
			this.Controls.Add(this.pnlViewError);
			this.Controls.Add(this.pnlViewLogin);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.Text = "Strava TCX Downloader";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.pnlViewLogin.ResumeLayout(false);
			this.pnlViewLogin.PerformLayout();
			this.pnlViewError.ResumeLayout(false);
			this.pnlViewActivityListAquire.ResumeLayout(false);
			this.pnlViewTCXDownload.ResumeLayout(false);
			this.pnlViewComplete.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbCheck)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtAPIKey;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Panel pnlViewLogin;
		private System.Windows.Forms.Panel pnlViewError;
		private System.Windows.Forms.Label lblErrorMessage;
		private System.Windows.Forms.Button btnErrorClose;
		private System.Windows.Forms.Panel pnlViewActivityListAquire;
		private System.Windows.Forms.Label lblAquireStatus;
		private System.Windows.Forms.Button btnAbort;
		private System.Windows.Forms.Panel pnlViewTCXDownload;
		private System.Windows.Forms.Label lblTCXStatus;
		private System.Windows.Forms.Button btnTCXAbort;
		private System.Windows.Forms.ProgressBar pbProgress;
		private System.Windows.Forms.Panel pnlViewComplete;
		private System.Windows.Forms.PictureBox pbCheck;
		private System.Windows.Forms.LinkLabel llblShowFolder;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnCompleteClose;
	}
}

