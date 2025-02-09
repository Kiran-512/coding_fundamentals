using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Models;
using All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory.Abstract_Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Abstract_Factory.Car_Factory
{
    public class CarFactoryClient
    {
        public static void Main1()
        {
            //yaha par tum directly factory se group of similar producst can be created or else from car factory only, there would be another layer which will
            //create the car engine and car tyre when user says createVehicle()

            //The Abstract Factory defines the interface for creating families of related objects (vehicle, engine, and tire).
            
            IVehicleFactory factroy = new CarFactory();
            IVehicle vehicle  = factroy.CreateVehicle();

            factroy.CreateEngine().Start();
            factroy.CreateTyre().Inflate();
            vehicle.Drive();

            factroy = new BikeFactory();
            vehicle = factroy.CreateVehicle();

            factroy.CreateEngine().Start();
            factroy.CreateTyre().Inflate();

            vehicle.Drive();
            
            Console.ReadLine();
        }
    }
}
//Key Points in This Complex Example
//Families of Products:

//Each factory produces a related set of products: IVehicle, IEngine, and ITire.
//Compatibility between parts (e.g., CarEngine and CarTire) is ensured by using the same factory.

//Scalability:
//Adding a new type of vehicle(e.g., Truck) requires creating a new TruckFactory and corresponding product classes (e.g., TruckEngine, TruckTire).

//Abstraction:
//The client code(Main method) works only with the IVehicleFactory interface and does not care about the specific implementations.
