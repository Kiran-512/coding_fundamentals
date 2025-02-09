using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Models
{
    public class Truck : Vehicle
    {
        public override ParkingTicket GetTicket()
        {
            return null;
        }

    }
}
