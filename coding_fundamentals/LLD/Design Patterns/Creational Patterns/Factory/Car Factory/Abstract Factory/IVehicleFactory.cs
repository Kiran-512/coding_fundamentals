using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface;
using All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory.Abstract_Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.LLD.Design_Patterns.Creational_Patterns.Factory.CarFactory.Abstract_Factory
{
    internal interface IVehicleFactory
    {
        IVehicle CreateVehicle();
    }
}
