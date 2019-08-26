using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Patterns.Creational.Prototypes
{
    // The prototype design pattern is used to create a duplicate or clone of an object which can be used as a prototype instance for creating other similar objects.

    abstract class Prototype
    {
        public int Id { get; private set; }

        protected Prototype(int id)
        {
            Id = id;
        }

        public abstract Prototype Clone();
    }
}
