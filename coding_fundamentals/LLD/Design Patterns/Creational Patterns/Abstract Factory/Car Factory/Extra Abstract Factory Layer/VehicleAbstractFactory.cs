using All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Abstract_Factory.Car_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_fundamentals.LLD.Design_Patterns.Creational_Patterns
{
    public class VehicleAbstractFactory
    {
        internal static IVehicleFactory CreateFactory(string type)
        {
            switch (type)
            {
                case "Car":
                    return new CarFactory();
                case "Bike":
                    return new BikeFactory();
                default:
                    break;
            }
            return null;
        }
    }
}
