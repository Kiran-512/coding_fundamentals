using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Abstract_Factory.Car_Factory
{
    //The Abstract Factory defines the interface for creating families of related objects (vehicle, engine, and tire).
    interface IVehicleFactory
    {
        IVehicle CreateVehicle();
        IEngine CreateEngine();
        ITyre CreateTyre();
    }
}
