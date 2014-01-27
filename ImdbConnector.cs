using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace XbmcImdbScoreUpdaterV2
{
    static class ImdbConnector
    {
        public static ImdbData GetImdbData(string ImdbID)
        {
            try
            {
                //read the HTML source for the IMDB page relating to the IMDB ID passed
                WebClient w = new WebClient();
                string page = w.DownloadString(@"http://www.imdb.com/title/" + ImdbID + "/");

                //set default values
                string title = null;
                decimal rating = -1;
                int count = -1;

                //attempt to scrape the HTML
                try
                {
                    //look for the title. Try several regular expressions to parse the title
                    Match matchTitle1 = Regex.Match(page, @"<meta property='og:Title' content=""(.*)(\(\d{4}\))"" />", RegexOptions.IgnoreCase);
                    if (matchTitle1.Success)
                        title = matchTitle1.Groups[1].Value;
                    else
                    {
                        Match matchTitle2 = Regex.Match(page, @"<meta property='og:Title' content=""(.*)(\(TV Movie \d{4}\))"" />", RegexOptions.IgnoreCase);
                        if (matchTitle2.Success)
                            title = matchTitle2.Groups[1].Value;
                        else
                        {
                            Match matchTitle3 = Regex.Match(page, @"<meta property='og:Title' content=""(.*)(\(Video \d{4}\))"" />", RegexOptions.IgnoreCase);
                            if (matchTitle3.Success)
                                title = matchTitle3.Groups[1].Value;
                            else
                            {
                                Match matchTitle4 = Regex.Match(page, @"<meta property='og:Title' content=""(.*)(\(TV Episode \d{4}\))"" />", RegexOptions.IgnoreCase);
                                if (matchTitle3.Success)
                                    title = matchTitle4.Groups[1].Value;
                            }
                        }
                    }

                    //look for the rating
                    Match matchRating = Regex.Match(page, @"<span itemprop=""ratingValue"">(\d\.\d)</span>", RegexOptions.IgnoreCase);
                    if (matchRating.Success)
                        rating = Convert.ToDecimal(matchRating.Groups[1].Value);

                    //look for the number of votes
                    Match matchCount = Regex.Match(page, @"<span itemprop=""ratingCount"">(.*)</span>", RegexOptions.IgnoreCase);
                    if (matchCount.Success)
                    {
                        string temp = matchCount.Groups[1].Value;
                        temp = temp.Replace(",", "");
                        count = Convert.ToInt32(temp);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Unable to scrape: " + ImdbID + Environment.NewLine + ex.ToString());
                }

                //if successful, return the data
                if (title != null && rating != -1 && count != -1)
                    return new ImdbData(ImdbID, title, rating, count);
                else
                    Tools.WriteLogLine("Unable to retrieve IMDB score data: " + ImdbID);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            //if the code has reached this point, the scrape has failed so return null
            return null;
        }
    }
}
