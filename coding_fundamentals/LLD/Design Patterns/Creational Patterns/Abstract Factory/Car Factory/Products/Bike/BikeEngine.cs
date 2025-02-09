using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Abstract_Factory.Car_Factory
{
    internal class BikeEngine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Bike Engine is started");
        }
    }
}
