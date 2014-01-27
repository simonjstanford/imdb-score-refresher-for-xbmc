namespace XbmcImdbScoreUpdaterV2
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.labelAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBoxMySQLConnection = new System.Windows.Forms.GroupBox();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelServerIP = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.radioButtonMySQL = new System.Windows.Forms.RadioButton();
            this.radioButtonSQLite = new System.Windows.Forms.RadioButton();
            this.groupBoxSqliteConnection = new System.Windows.Forms.GroupBox();
            this.labelLocalPath = new System.Windows.Forms.Label();
            this.textBoxLocalDBPath = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.groupBoxMySQLConnection.SuspendLayout();
            this.groupBoxSqliteConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.labelAction});
            this.statusStrip1.Location = new System.Drawing.Point(0, 354);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(342, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // labelAction
            // 
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(0, 17);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMySQL_RunWorkerCompleted);
            // 
            // groupBoxMySQLConnection
            // 
            this.groupBoxMySQLConnection.Controls.Add(this.textBoxDatabase);
            this.groupBoxMySQLConnection.Controls.Add(this.labelDatabase);
            this.groupBoxMySQLConnection.Controls.Add(this.labelPort);
            this.groupBoxMySQLConnection.Controls.Add(this.textBoxPort);
            this.groupBoxMySQLConnection.Controls.Add(this.labelServerIP);
            this.groupBoxMySQLConnection.Controls.Add(this.textBoxPassword);
            this.groupBoxMySQLConnection.Controls.Add(this.labelPassword);
            this.groupBoxMySQLConnection.Controls.Add(this.textBoxServerIP);
            this.groupBoxMySQLConnection.Controls.Add(this.labelUser);
            this.groupBoxMySQLConnection.Controls.Add(this.textBoxUsername);
            this.groupBoxMySQLConnection.Location = new System.Drawing.Point(12, 35);
            this.groupBoxMySQLConnection.Name = "groupBoxMySQLConnection";
            this.groupBoxMySQLConnection.Size = new System.Drawing.Size(318, 158);
            this.groupBoxMySQLConnection.TabIndex = 14;
            this.groupBoxMySQLConnection.TabStop = false;
            this.groupBoxMySQLConnection.Text = "MySQL Server Connection";
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Location = new System.Drawing.Point(80, 71);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(232, 20);
            this.textBoxDatabase.TabIndex = 6;
            // 
            // labelDatabase
            // 
            this.labelDatabase.AutoSize = true;
            this.labelDatabase.Location = new System.Drawing.Point(6, 74);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(56, 13);
            this.labelDatabase.TabIndex = 5;
            this.labelDatabase.Text = "Database:";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(6, 48);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 7;
            this.labelPort.Text = "Port:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(80, 45);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(232, 20);
            this.textBoxPort.TabIndex = 4;
            // 
            // labelServerIP
            // 
            this.labelServerIP.AutoSize = true;
            this.labelServerIP.Location = new System.Drawing.Point(6, 22);
            this.labelServerIP.Name = "labelServerIP";
            this.labelServerIP.Size = new System.Drawing.Size(54, 13);
            this.labelServerIP.TabIndex = 3;
            this.labelServerIP.Text = "Server IP:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(80, 123);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(232, 20);
            this.textBoxPassword.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(6, 126);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(80, 19);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(232, 20);
            this.textBoxServerIP.TabIndex = 0;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(6, 100);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(58, 13);
            this.labelUser.TabIndex = 2;
            this.labelUser.Text = "Username:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(80, 97);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(232, 20);
            this.textBoxUsername.TabIndex = 1;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(255, 319);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 13;
            this.buttonRun.Text = "Run!";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // radioButtonMySQL
            // 
            this.radioButtonMySQL.AutoSize = true;
            this.radioButtonMySQL.Location = new System.Drawing.Point(12, 12);
            this.radioButtonMySQL.Name = "radioButtonMySQL";
            this.radioButtonMySQL.Size = new System.Drawing.Size(134, 17);
            this.radioButtonMySQL.TabIndex = 4;
            this.radioButtonMySQL.TabStop = true;
            this.radioButtonMySQL.Text = "Remote MySQL Server";
            this.radioButtonMySQL.UseVisualStyleBackColor = true;
            this.radioButtonMySQL.CheckedChanged += new System.EventHandler(this.radioButtonMySQL_CheckedChanged);
            // 
            // radioButtonSQLite
            // 
            this.radioButtonSQLite.AutoSize = true;
            this.radioButtonSQLite.Location = new System.Drawing.Point(12, 199);
            this.radioButtonSQLite.Name = "radioButtonSQLite";
            this.radioButtonSQLite.Size = new System.Drawing.Size(135, 17);
            this.radioButtonSQLite.TabIndex = 5;
            this.radioButtonSQLite.TabStop = true;
            this.radioButtonSQLite.Text = "Local SQLite Database";
            this.radioButtonSQLite.UseVisualStyleBackColor = true;
            this.radioButtonSQLite.CheckedChanged += new System.EventHandler(this.radioButtonSQLite_CheckedChanged);
            // 
            // groupBoxSqliteConnection
            // 
            this.groupBoxSqliteConnection.Controls.Add(this.labelLocalPath);
            this.groupBoxSqliteConnection.Controls.Add(this.textBoxLocalDBPath);
            this.groupBoxSqliteConnection.Location = new System.Drawing.Point(12, 222);
            this.groupBoxSqliteConnection.Name = "groupBoxSqliteConnection";
            this.groupBoxSqliteConnection.Size = new System.Drawing.Size(318, 81);
            this.groupBoxSqliteConnection.TabIndex = 15;
            this.groupBoxSqliteConnection.TabStop = false;
            this.groupBoxSqliteConnection.Text = "XBMC Movie Database File Location";
            // 
            // labelLocalPath
            // 
            this.labelLocalPath.AutoSize = true;
            this.labelLocalPath.Location = new System.Drawing.Point(3, 16);
            this.labelLocalPath.Name = "labelLocalPath";
            this.labelLocalPath.Size = new System.Drawing.Size(32, 13);
            this.labelLocalPath.TabIndex = 3;
            this.labelLocalPath.Text = "Path:";
            // 
            // textBoxLocalDBPath
            // 
            this.textBoxLocalDBPath.Location = new System.Drawing.Point(3, 32);
            this.textBoxLocalDBPath.Name = "textBoxLocalDBPath";
            this.textBoxLocalDBPath.Size = new System.Drawing.Size(309, 20);
            this.textBoxLocalDBPath.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 376);
            this.Controls.Add(this.groupBoxSqliteConnection);
            this.Controls.Add(this.radioButtonMySQL);
            this.Controls.Add(this.radioButtonSQLite);
            this.Controls.Add(this.groupBoxMySQLConnection);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "XBMC IMDB Score Refresher 2.5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxMySQLConnection.ResumeLayout(false);
            this.groupBoxMySQLConnection.PerformLayout();
            this.groupBoxSqliteConnection.ResumeLayout(false);
            this.groupBoxSqliteConnection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel labelAction;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.GroupBox groupBoxMySQLConnection;
        private System.Windows.Forms.Label labelServerIP;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.RadioButton radioButtonMySQL;
        private System.Windows.Forms.RadioButton radioButtonSQLite;
        private System.Windows.Forms.GroupBox groupBoxSqliteConnection;
        private System.Windows.Forms.Label labelLocalPath;
        private System.Windows.Forms.TextBox textBoxLocalDBPath;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.Label labelDatabase;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
    }
}

