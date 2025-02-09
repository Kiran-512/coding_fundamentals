using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Abstract_Factory.Car_Factory
{
    internal class BikeTyre : ITyre
    {
        public void Inflate()
        {
            Console.WriteLine("Bike Tyre is inflated");
        }
    }
}
