using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDataAccessLayer;
using RestaurantComp;
using Reviews;
using AReviews;

namespace LibraryConversion
{
    public class LibraryConverter
    {
        List<RestaurantComp.Restaurant> restList;
        RestaurantCrud crud;

        public LibraryConverter()
        {
            restList = new List<RestaurantComp.Restaurant>();
            crud = new RestaurantCrud();
        }

        public List<RestaurantComp.Restaurant> DataToLibConversion()
        {
            foreach (RestaurantDataAccessLayer.Restaurant x in crud.restaurantList)
            {
                restList.Add(new RestaurantComp.Restaurant(x.RName, x.Cuisine));
                foreach (RestaurantDataAccessLayer.Review y in crud.reviewList)
                {
                    if(y.RestaurantID == x.RestaurantID)
                    {
                        restList[x.RestaurantID-1].AddReview(new Reviews.Review((double)y.Rating, y.written));
                    }
                }
            }

            return restList;
        }
    }
}
