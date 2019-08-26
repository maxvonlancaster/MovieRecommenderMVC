using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Patterns.Creational.Prototypes
{
    class ConcreteP1 : Prototype
    {
        public ConcreteP1(int id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return new ConcreteP1(Id);
        }
    }
}
