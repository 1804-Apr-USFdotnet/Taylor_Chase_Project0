using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantComp;
using AReviews;
using Reviews;

namespace SerializeHelper
{
    public class RestaurantSerializer
    {
        public static void RestaurantSerialization(Restaurant x)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Review));
            System.IO.FileStream stream;
            string path;
            Type[] extras = new Type[] { typeof(AReview), typeof(Review) };
            writer = new System.Xml.Serialization.XmlSerializer(typeof(Restaurant), extras);
            path = String.Concat(@"C:\revature\Taylor_Chase_Project0\Taylor_Chase_Project0Code\XMLTextDocs\", x.name, ".xml");
            stream = System.IO.File.Create(path);
            writer.Serialize(stream, x);
            stream.Close();
        }

        public static void RestaurantDeserialization(Restaurant x)
        {
            
        }
    }
}
