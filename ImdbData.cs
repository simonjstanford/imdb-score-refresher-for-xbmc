using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XbmcImdbScoreUpdaterV2
{
    class ImdbData
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public decimal Rating { get; set; }
        public int RatingCount { get; set; }

        public ImdbData(string id, string title, decimal rating, int ratingCount)
        {
            this.ID = id;
            this.Title = title;
            this.Rating = rating;
            this.RatingCount = ratingCount;
        }

        public override string ToString()
        {
            return ID + Environment.NewLine + Title + Environment.NewLine + Rating + Environment.NewLine + RatingCount;
        }

    }
}
