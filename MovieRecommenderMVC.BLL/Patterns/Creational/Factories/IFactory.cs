using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Patterns.Creational.Factories
{
    // Factory pattern - provides interface for creation of objects of some type, but the decision on the object of which class to creatw happens in the subclasses

    public interface IFactory
    {
        IRecomendationService FactoryMethod();
    }
}
