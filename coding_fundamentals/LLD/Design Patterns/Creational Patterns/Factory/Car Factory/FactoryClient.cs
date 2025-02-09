using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface;
using All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory.Abstract_Factory;
using All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory.Abstract_Product;
using All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory
{
    public class FactoryClient
    {
        public static void Main1()
        {
            IVehicleFactory factory = new CarFactorry();
            IVehicle car = factory.CreateVehicle();
            car.Start();

            factory = new BikeFactory();
            IVehicle bike = factory.CreateVehicle();
            bike.Start();
        }
    }
}
