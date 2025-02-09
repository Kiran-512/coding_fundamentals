using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Abstract_Factory.Car_Factory
{
    internal class CarEngine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Car Engine started");
        }
    }
}
