using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AReviews;

namespace Reviews
{
    [Serializable]
    public class Review : AReview
    {   
        //public double rating { get; set; }
        //public string written { get; set; }
        public Review()
        {
            rating = 0;
            written = null;
        }

        public Review(double rating)
        {
            this.rating = rating;
            written = null;
        }

        public Review(double rating, string written)
        {
            this.rating = rating;
            this.written = written;
        }

    }
}
