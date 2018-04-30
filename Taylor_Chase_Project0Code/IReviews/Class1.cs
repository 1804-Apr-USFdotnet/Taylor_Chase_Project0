using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AReviews
{
    [Serializable]
    public abstract class AReview  
    {
        public double rating { get; set; }
        public string written { get; set; }
    }
}
