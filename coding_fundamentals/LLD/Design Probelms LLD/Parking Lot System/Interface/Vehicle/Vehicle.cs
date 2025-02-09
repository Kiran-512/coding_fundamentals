using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface
{
    public abstract class Vehicle
    {
        private string RegNo { get; set; }

        public Vehicle()
        { }
        public Vehicle(string regNo)
        {
            RegNo = regNo;
        }

        protected ParkingTicket ticket { get; set; }

        public abstract ParkingTicket GetTicket();
    }
}
