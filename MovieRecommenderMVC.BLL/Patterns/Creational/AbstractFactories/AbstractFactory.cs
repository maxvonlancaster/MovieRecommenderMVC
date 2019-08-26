using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Patterns.Creational.AbstractFactories
{
    internal abstract class AbstractFactory
    {
        public abstract AbstractServiceA CreateServiceA();

        public abstract AbstractServiceB CreateServiceB();

    }

    internal abstract class AbstractServiceA { }

    internal abstract class AbstractServiceB { }

    class ConcreteFactoryC : AbstractFactory
    {
        public override AbstractServiceA CreateServiceA()
        {
            return new ServiceAC();
        }

        public override AbstractServiceB CreateServiceB()
        {
            return new ServiceBC();
        }
    }

    class ConcreteFactoryD : AbstractFactory
    {
        public override AbstractServiceA CreateServiceA()
        {
            return new ServiceAD();
        }

        public override AbstractServiceB CreateServiceB()
        {
            return new ServiceBD();
        }
    }

    class ServiceAC : AbstractServiceA { }

    class ServiceAD : AbstractServiceA { }

    class ServiceBC : AbstractServiceB { }

    class ServiceBD : AbstractServiceB { }

}
