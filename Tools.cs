using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XbmcImdbScoreUpdaterV2
{
    static class Tools
    {
        public static void WriteLogLine(string text)
        {
            try
            {
                using (StreamWriter sw = File.AppendText("Log.txt"))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "\t" + text);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Unable to write log file: " + Environment.NewLine + ex.ToString());
            }

        }
    }
}
