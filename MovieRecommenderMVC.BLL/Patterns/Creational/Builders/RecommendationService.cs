using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Patterns.Creational.Builders
{
    public class RecommendationService
    {
        List<object> services = new List<object>();

        public void Add(object service)
        {
            services.Add(service);
        }
    }
}
