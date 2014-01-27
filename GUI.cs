using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XbmcImdbScoreUpdaterV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //if no saved properties exist, set default values
            if (Properties.Settings.Default.Port == 0)
                Properties.Settings.Default.Port = 3306;

            if (Properties.Settings.Default.Database.Count() < 1)
                Properties.Settings.Default.Database = "myvideos75";

            if (Properties.Settings.Default.Username.Count() < 1)
                Properties.Settings.Default.Username = "xbmc";

            if (Properties.Settings.Default.Password.Count() < 1)
                Properties.Settings.Default.Password = "xbmc";
         
            Properties.Settings.Default.Save();

            //enable last used database type in the window
            if (Properties.Settings.Default.MySQL)
            {
                radioButtonMySQL.Checked = true;
                radioButtonSQLite.Checked = false;
                groupBoxMySQLConnection.Enabled = true;
                groupBoxSqliteConnection.Enabled = false;
            }
            else
            {
                radioButtonSQLite.Checked = true;
                radioButtonMySQL.Checked = false;
                groupBoxMySQLConnection.Enabled = false;
                groupBoxSqliteConnection.Enabled = true;
            }

            //Retrieve previous settings
            textBoxServerIP.Text = Properties.Settings.Default.ServerIP;
            textBoxUsername.Text = Properties.Settings.Default.Username;
            textBoxPassword.Text = Properties.Settings.Default.Password;
            textBoxLocalDBPath.Text = Properties.Settings.Default.LocalDBFile;
            textBoxDatabase.Text = Properties.Settings.Default.Database;
            textBoxPort.Text = Properties.Settings.Default.Port.ToString();

            if (textBoxLocalDBPath.Text.Length < 1)
                textBoxLocalDBPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\XBMC\userdata\Database\MyVideos75.db";
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Get the IMDB IDs from the XBMC database
            IDatabaseConnector ExtractIds;
            
            if (radioButtonMySQL.Checked)
                ExtractIds = new XbmcMySqlConnector(Properties.Settings.Default.ServerIP, Properties.Settings.Default.Username, Properties.Settings.Default.Password, Properties.Settings.Default.Database, Properties.Settings.Default.Port);
            else
                ExtractIds = new XbmcSqlLiteConnector(Properties.Settings.Default.LocalDBFile);           

            labelAction.Text = "Getting IMDB IDs from XBMC....";
            List<string> Ids = ExtractIds.ExportImdbIDs();
            
            //Using the IMDB IDs, get the updated score and number of votes
            List<ImdbData> ImdbInfo = new List<ImdbData>();
            labelAction.Text = "Getting current ratings from IMDB....";           

            foreach (string id in Ids)
            {
                ImdbData data = ImdbConnector.GetImdbData(id);
                if (data != null) ImdbInfo.Add(data);
                    
                double percentage = (100 / (double)Ids.Count) * Ids.IndexOf(id);
                backgroundWorker.ReportProgress((int)percentage);              
            }
            backgroundWorker.ReportProgress(0);
           
            //insert the new scores into the database
            labelAction.Text = "Inserting new ratings into database....";
            
            IDatabaseConnector ImportImdbInfo;
            if (radioButtonMySQL.Checked)
                ImportImdbInfo = new XbmcMySqlConnector(Properties.Settings.Default.ServerIP, Properties.Settings.Default.Username, Properties.Settings.Default.Password, ImdbInfo, Properties.Settings.Default.Database, Properties.Settings.Default.Port);
            else
                ImportImdbInfo = new XbmcSqlLiteConnector(Properties.Settings.Default.LocalDBFile, ImdbInfo);

            int result = ImportImdbInfo.ImportImdbData();

            e.Result = result;          
        }

        private void backgroundWorkerMySQL_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelAction.Text = "Finished! " + (int)e.Result + " movies changed";
        }

        private void radioButtonMySQL_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMySQL.Checked)
                groupBoxMySQLConnection.Enabled = true;
            else
                groupBoxMySQLConnection.Enabled = false;
        }

        private void radioButtonSQLite_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSQLite.Checked)
                groupBoxSqliteConnection.Enabled = true;
            else
                groupBoxSqliteConnection.Enabled = false;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            //save settings
            Properties.Settings.Default.ServerIP = textBoxServerIP.Text;
            Properties.Settings.Default.Username = textBoxUsername.Text;
            Properties.Settings.Default.Password = textBoxPassword.Text;
            Properties.Settings.Default.MySQL = radioButtonMySQL.Checked;
            Properties.Settings.Default.LocalDBFile = textBoxLocalDBPath.Text;
            Properties.Settings.Default.Database = textBoxDatabase.Text;
            Properties.Settings.Default.Port = Convert.ToInt32(textBoxPort.Text);

            Properties.Settings.Default.Save();

            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }
    }
}
