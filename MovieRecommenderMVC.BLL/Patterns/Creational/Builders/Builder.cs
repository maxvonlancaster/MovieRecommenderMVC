using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Patterns.Creational.Builders
{
    // The intent - to separate the constructor of a complex object from its representation.

    public abstract class Builder
    {
        public abstract void BuildServiceA();
        public abstract void BuildServiceB();
        public abstract void BuildServiceC();
        public abstract RecommendationService GetService();
    }
}
