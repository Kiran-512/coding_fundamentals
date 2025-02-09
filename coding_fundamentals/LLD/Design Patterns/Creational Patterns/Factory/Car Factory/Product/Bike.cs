using All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory.Abstract_Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory.Product
{
    internal class Bike : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Bike started");
        }
    }
}
