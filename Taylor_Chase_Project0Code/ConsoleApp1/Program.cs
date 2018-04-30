using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantComp;
using LibraryConversion;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<RestaurantComp.Restaurant> restaurants = new LibraryConverter().DataToLibConversion();
            restaurants.Sort(new BestToWorstSorter());

            foreach (Restaurant x in restaurants)
            {
                Console.WriteLine("Restaurant Name: {0}  Cuisine: {1}", x.name, x.cuisine);
            }

            Console.WriteLine("*******************");
            Console.Write("The Three Best are ");
            for (int i = 0; i < 3; i++)
            {
                if(i <= restaurants.Count -1)
                {
                    Console.WriteLine("Restaurant Name: {0}  Cuisine: {1}", restaurants[i].name, restaurants[i].cuisine);
                }
            }

            foreach (Restaurant x in restaurants)
            {
                x.PrintReviews();
            }

            Console.WriteLine("Search for Restaurant here");

            string searchString = Console.ReadLine();

            foreach (Restaurant x in restaurants)
            {
                if (x.name.Contains(searchString))
                {
                    Console.WriteLine("************");
                    Console.WriteLine("Restaurant Found! {0}  Cuisine {1}", x.name, x.cuisine);
                }
                else
                {
                    Console.WriteLine("Searching");
                }
            }



        }

        public class BestToWorstSorter : IComparer<Restaurant>
        {
            public int Compare(Restaurant x, Restaurant y)
            {
                if (x.CalculateAverageRating().Equals(0))
                {
                    if (y.CalculateAverageRating().Equals(0))
                    {
                        return 0;
                    }
                    else { return -1; }
                }
                else
                {
                    if (y.CalculateAverageRating().Equals(0))
                    {
                        return 1;
                    }
                    else
                    {
                        if (x.CalculateAverageRating() < y.CalculateAverageRating())
                        {
                            return 1;
                        }
                        else if (x.CalculateAverageRating() > y.CalculateAverageRating())
                        {
                            return -1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
        }

        public class WorstToBestRatingSorter : IComparer<Restaurant>
        {
            public int Compare(Restaurant x, Restaurant y)
            {
                if (x.CalculateAverageRating().Equals(0))
                {
                    if (y.CalculateAverageRating().Equals(0))
                    {
                        return 0;
                    }
                    else { return -1; }
                }
                else
                {
                    if (y.CalculateAverageRating().Equals(0))
                    {
                        return 1;
                    }
                    else
                    {
                        if (x.CalculateAverageRating() > y.CalculateAverageRating())
                        {
                            return 1;
                        }
                        else if (x.CalculateAverageRating() < y.CalculateAverageRating())
                        {
                            return -1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
        }
    }
}
