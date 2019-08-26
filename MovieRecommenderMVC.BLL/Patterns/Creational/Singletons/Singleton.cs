using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Patterns.Creational.Singletons
{
    // Singleton is a class which only allows a single instance of it to be created.
    // In the app runtime, only one single instance of the singleton class will exist for all users.

    public class SingletonRecommendationService
    {
        private static SingletonRecommendationService instance;

        private SingletonRecommendationService() { }

        public static SingletonRecommendationService getInstance()
        {
            if (instance == null)
            {
                instance = new SingletonRecommendationService();
            }
            return instance;
        }
    }
}
