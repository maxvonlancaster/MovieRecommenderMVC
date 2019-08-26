using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Patterns.Creational.Builders
{
    public class ConcreteBuilder : Builder
    {
        RecommendationService service = new RecommendationService();

        public override void BuildServiceA()
        {
            service.Add("A");
        }

        public override void BuildServiceB()
        {
            service.Add("B");
        }

        public override void BuildServiceC()
        {
            service.Add("C");
        }

        public override RecommendationService GetService()
        {
            return service;
        }
    }
}
