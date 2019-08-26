using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Patterns.Creational.Factories
{
    public class RatingRecomendationFactory : IFactory
    {
        public IRecomendationService FactoryMethod()
        {
            return new RatingRecomandation();
        }
    }
}
