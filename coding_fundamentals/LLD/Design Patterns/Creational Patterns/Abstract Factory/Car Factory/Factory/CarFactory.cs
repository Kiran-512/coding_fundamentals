using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Abstract_Factory.Car_Factory
{
    internal class CarFactory : IVehicleFactory
    {
        public IEngine CreateEngine()
        {
            return new CarEngine();
        }

        public ITyre CreateTyre()
        {
            return new CarTyre();
        }

        public IVehicle CreateVehicle()
        {
            return new Car();
        }
    }
}
