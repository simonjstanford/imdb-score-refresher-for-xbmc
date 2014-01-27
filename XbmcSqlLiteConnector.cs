using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace XbmcImdbScoreUpdaterV2
{
    /// <summary>
    /// Executes an SQL select and update statements to retrieve IMDB IDs and then refresh the IMDB score.  Used to work with a local XBMC SQLite database file.
    /// </summary>
    class XbmcSqlLiteConnector : IDatabaseConnector
    {
        private List<ImdbData> ImdbInfo;
        SQLiteCommand command;

        /// <summary>
        /// Communicates with a local SQLite database file to run a batch of SQL update commands to refresh the IMDB score in XBMC.
        /// </summary>
        /// <param name="watchedFiles">A collection of XbmcFile objects that has been parsed from a watched.xml file</param>
        public XbmcSqlLiteConnector(string path, List<ImdbData> imdbInfo)
        {
            //populate properties
            ImdbInfo = imdbInfo;
            SQLiteConnection connection = new SQLiteConnection(buildConnectionString(path));

            string updateCommand = buildSqliteImportCommand();

            command = new SQLiteCommand(updateCommand, connection); //build the connection string
            command.CommandTimeout = 0; //build the SQL command         
        }

        /// <summary>
        /// Communicates with a local SQLite database file to run an SQL select command to retrieve IMDB IDs from XBMC.
        /// </summary>
        public XbmcSqlLiteConnector(string path)
        {
            SQLiteConnection connection = new SQLiteConnection(buildConnectionString(path)); //build the connection string
            string updateCommand = "SELECT c09 FROM movie WHERE c09 != '';"; //build the SQL command
            command = new SQLiteCommand(updateCommand, connection);
            command.CommandTimeout = 0; //disable timeout setting
        }

        /// <summary>
        /// Builds the batch of SQL update commands
        /// </summary>
        /// <returns>An SQL command with multiple UPDATE statements</returns>
        private string buildSqliteImportCommand()
        {
            StringBuilder commands = new StringBuilder();
            foreach (ImdbData data in ImdbInfo)
            {
                string command = "UPDATE movie SET c05='" + data.Rating + "', c04='" + data.RatingCount + "' WHERE c09= '" + data.ID + "'; " + Environment.NewLine;
                commands.Append(command);
            }

            return commands.ToString();
        }

        /// <summary>
        /// Build the SQLite Connection String.
        /// </summary>
        /// <returns>A connection string that will connect to a Sqlite database</returns>
        private string buildConnectionString(string path)
        {
            string connectionString = @"data source=" + path + "; Version=3;";
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

            SQLiteDataReader myReader;
            command.Connection.Open();
            myReader = command.ExecuteReader();
            try
            {
                //read the data from the SQLite file and create the XbmcFile objects
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
                myReader.Close();
                command.Connection.Close();
            }
            return IDs;
        }
    }
}
