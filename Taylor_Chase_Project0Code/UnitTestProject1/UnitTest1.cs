using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reviews;
using RestaurantComp;
using AReviews;
using SerializeHelper;
using RestaurantDataAccessLayer;
using LibraryConversion;

namespace ReviewTest
{
    [TestClass]
    public class Tester
    {
        [TestMethod]
        public void TestReviews()
        {
            //arrange
            Reviews.Review review1 = new Reviews.Review();
            Reviews.Review review2 = new Reviews.Review(4.3);
            Reviews.Review review3 = new Reviews.Review(2.3, "The service was slow and the food was soggy. I would not recommend!");

            //act
            review1.rating = 3.9;
            review1.written = "Eh";
            review2.written = "I enjoyed the food quite a bit, but the service was lacking";
            review3.rating = 1.7;

            //assert
            Assert.AreEqual(review1.written, "Eh");
            Assert.AreEqual(1.7, review3.rating);
            Assert.AreEqual(review2.rating, 4.3);
        }


        [TestMethod]
        public void TestRestaurant()
        {
            //arrange
            RestaurantComp.Restaurant restaurant1 = new RestaurantComp.Restaurant();
            RestaurantComp.Restaurant restaurant2 = new RestaurantComp.Restaurant("Willie's");
            RestaurantComp.Restaurant restaurant3 = new RestaurantComp.Restaurant("Maria's", "Mexican");
            RestaurantComp.Restaurant restaurant4 = new RestaurantComp.Restaurant("Pete's", "Steakhouse", new Reviews.Review(2.2));

            //act
            restaurant1.name = "Mueller's";
            restaurant2.cuisine = "Sports bar";
            restaurant3.AddReview(new Reviews.Review());
            restaurant4.reviews[0].written = "Slightly outdated and food is a little weak, however it has a warm service";
            restaurant4.AddReview(new Reviews.Review());
            restaurant4.SortReviewWorstToBest();

            //assert
            Assert.AreEqual(null, restaurant1.cuisine);
            Assert.AreEqual("Mueller's", restaurant1.name);
            Assert.AreEqual("Sports bar", restaurant2.cuisine);
            Assert.AreEqual(null, restaurant3.reviews[0].written);
            Assert.AreEqual(0, restaurant3.reviews[0].rating);
            Assert.AreEqual(2.2, restaurant4.reviews[1].rating);
        }

        [TestMethod]
        public void TestSerialize()
        {
            //arrange
            RestaurantComp.Restaurant restaurant = new RestaurantComp.Restaurant("Willies", "Sports Bar", new Reviews.Review(4.6, "Everything was great!"));

            //act
            restaurant.AddReview(new Reviews.Review(4.9, "Absolutely Fantastic"));
            RestaurantSerializer.RestaurantSerialization(restaurant);

            //assert
            Assert.IsTrue(System.IO.File.Exists(String.Concat(@"C:\revature\Taylor_Chase_Project0\Taylor_Chase_Project0Code\XMLTextDocs\", restaurant.name, ".xml")));
        }

        [TestMethod]
        public void TestDataAccess()
        {
            //arrange
            RestaurantCrud crud = new RestaurantCrud();

            //act
            RestaurantComp.Restaurant restaurant2 = new RestaurantComp.Restaurant(crud.RetrieveRestaurant(0).RName, crud.RetrieveRestaurant(0).Cuisine, new Reviews.Review((double)crud.reviewList[0].Rating, crud.reviewList[0].written));

            //assert
            Assert.AreEqual(restaurant2.name.ToLower(), "Willies".ToLower());
            Assert.AreEqual(restaurant2.cuisine.ToLower(), "Sports Bar".ToLower());
            Assert.AreEqual(restaurant2.reviews[0].rating, 4.6);

        }

        [TestMethod]
        public void TestDataToLibConversion()
        {
            //arrange
            LibraryConverter converter = new LibraryConverter();

            //act
            System.Collections.Generic.List<RestaurantComp.Restaurant> list = converter.DataToLibConversion();

            //assert
            Assert.AreEqual(list[0].name.ToLower(), "Willies".ToLower());
            Assert.AreEqual(list[0].cuisine.ToLower(), "Sports Bar".ToLower());
            Assert.AreEqual(list[0].reviews[0].rating, 4.6);
            //Assert.AreEqual(list[0].reviews[1].rating, 4.2);
        }
    }
}
