using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Patterns.Creational.Builders
{
    public class Director
    {
        private Builder _builder;

        public Director(Builder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.BuildServiceA();
            _builder.BuildServiceB();
            _builder.BuildServiceC();
        }
    }
}
