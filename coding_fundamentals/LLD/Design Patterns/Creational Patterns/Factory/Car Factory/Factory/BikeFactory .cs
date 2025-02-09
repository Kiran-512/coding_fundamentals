using All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory.Abstract_Factory;
using All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory.Abstract_Product;
using All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory.Factory
{
    internal class BikeFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle()
        {
            return new Bike();
        }
    }
}
