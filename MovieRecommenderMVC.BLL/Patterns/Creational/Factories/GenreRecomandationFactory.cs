using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Patterns.Creational.Factories
{
    public class GenreRecomandationFactory : IFactory
    {
        public IRecomendationService FactoryMethod()
        {
            return new GenreRecomendation();
        }
    }
}
