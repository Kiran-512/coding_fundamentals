using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Abstract_Factory.Car_Factory
{
    internal class BikeFactory : IVehicleFactory
    {
        public IEngine CreateEngine()
        {
            return new BikeEngine();
        }

        public ITyre CreateTyre()
        {
            return new BikeTyre();
        }
        public IVehicle CreateVehicle()
        {
            return new Bike();
        }
    }
}
