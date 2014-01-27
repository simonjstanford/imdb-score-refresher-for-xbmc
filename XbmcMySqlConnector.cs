using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace XbmcImdbScoreUpdaterV2
{
    /// <summary>
    /// Executes an SQL select and update statements to retrieve IMDB IDs and then refresh the IMDB score.  Used to work with a remote MySql database used in an XBMC shared library.
    /// </summary>
    class XbmcMySqlConnector : IDatabaseConnector
    {
        private List<ImdbData> ImdbInfo;
        private string serverLocation;
        private string sqlUserName;
        private string sqlPassword;
        private int sqlPort;
        private string database;
        public MySqlCommand command;

        /// <summary>
        /// Communicates with a remote MySQL database to run a batch of SQL update commands to refresh the IMDB score in XBMC.
        /// </summary>
        /// <param name="serverLocation">The IP address of the server</param>
        /// <param name="sqlUsername">The username for the SQL database - this is normally 'xbmc'</param>
        /// <param name="sqlPassword">The password for the SQL database - this is normally 'xbmc'</param>
        /// <param name="imdbInfo">A collection of ImdbData objects that contain IMDB IDs and movie score details</param>
        public XbmcMySqlConnector(string serverLocation, string sqlUsername, string sqlPassword, List<ImdbData> imdbInfo, string database, int port)
        {
            //populate properties
            ImdbInfo = imdbInfo;
            this.serverLocation = serverLocation;
            this.sqlUserName = sqlUsername;
            this.sqlPassword = sqlPassword;
            this.sqlPort = port;
            this.database = database;

            MySqlConnection connection = new MySqlConnection(buildConnectionString()); //build the connection string

            string updateCommand = buildSqlImportCommand(); //build the SQL command

            command = new MySqlCommand(updateCommand, connection);
            command.CommandTimeout = 0; //disable timeout setting
        }

        /// <summary>
        /// Communicates with a local SQLite database file to run an SQL select command to retrieve IMDB IDs from XBMC.
        /// </summary>
        /// <param name="serverLocation">The IP address of the server</param>
        /// <param name="sqlUsername">The username for the SQL database - this is normally 'xbmc'</param>
        /// <param name="sqlPassword">The password for the SQL database - this is normally 'xbmc'</param>
        public XbmcMySqlConnector(string serverLocation, string sqlUsername, string sqlPassword, string database, int port)
        {
            //populate properties
            this.serverLocation = serverLocation;
            this.sqlUserName = sqlUsername;
            this.sqlPassword = sqlPassword;
            this.sqlPort = port;
            this.database = database;

            MySqlConnection connection = new MySqlConnection(buildConnectionString()); //build the connection string

            string updateCommand = "SELECT c09 FROM " + database + ".movie WHERE c09 != ''"; //build the SQL command

            command = new MySqlCommand(updateCommand, connection);
            command.CommandTimeout = 0; //disable timeout setting
        }

        /// <summary>
        /// Builds the batch of SQL update commands
        /// </summary>
        /// <returns>An SQL command with multiple UPDATE statements</returns>
        private string buildSqlImportCommand()
        {
            StringBuilder commands = new StringBuilder();
            foreach (ImdbData data in ImdbInfo)
            {
                string command = "UPDATE " + database + ".movie SET c05='" + data.Rating + "', c04='" + data.RatingCount + "' WHERE c09= '" + data.ID + "'; " + Environment.NewLine;           
                commands.Append(command);
            }

            return commands.ToString();
        }

        /// <summary>
        /// Build the MySQL Connection String.
        /// </summary>
        /// <returns>A connection string that will connect to a MySQL database</returns>
        private string buildConnectionString()
        {
            string connectionString = "server=" + serverLocation + ";Port=" + sqlPort.ToString() + ";User Id='" + sqlUserName + "';password='" + sqlPassword + "';Persist Security Info=True;database=" + database;
            return connectionString;
        }

        /// <summary>
        /// Refresh the IMDB score in an SQLite database file
        /// </summary>
        /// <returns>The number of SQL Database rows affected by the change</returns>
        public int ImportImdbData()
        {
            int count = -1;
            try
            {
                command.Connection.Open();
                count = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                command.Connection.Close();            
            }
            return count; //return the number of database rows affected
        }

        /// <summary>
        /// Export the IMDB IDs from the SQLite database file into a .net collection
        /// </summary>
        /// <returns>A collection of XbmcFile objects, representing films/episodes in XBMC that have been watched</returns>
        public List<string> ExportImdbIDs()
        {
            List<string> IDs = new List<string>();
            MySqlDataReader myReader = null;

            try
            {
                command.Connection.Open();
                myReader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            
            try
            {
                //read the data sent back from MySQL server and create the XbmcFile objects
                while (myReader.Read())
                {
                    IDs.Add(myReader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (myReader != null) myReader.Close();
                command.Connection.Close();
            }
            return IDs;
        }
    }
}
