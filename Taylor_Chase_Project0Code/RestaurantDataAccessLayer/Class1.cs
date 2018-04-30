using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDataAccessLayer
{
    public class  RestaurantCrud
    {
        RestaurantDBEntities3 database;
        public List<Restaurant> restaurantList;
        public List<Review> reviewList;
        public RestaurantCrud()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            database = new RestaurantDBEntities3();
            restaurantList = database.Restaurants.ToList();
            reviewList = database.Reviews.ToList();
        }

        public Restaurant RetrieveRestaurant(int index)
        {
            return restaurantList[index];
        }

        //public List<Restaurant> RetrieveRestaurantList()
        //{
        //    return restaurantList;
        //}

        //public Review RetrieveReview(string Rname)
        //{

        //}

        //public string RetrieveReviewWritten(string Rname)
        //{
        //    return database.Reviews.Find(database.Restaurants.Find(Rname).RestaurantID).written;
        //}


    }
}
