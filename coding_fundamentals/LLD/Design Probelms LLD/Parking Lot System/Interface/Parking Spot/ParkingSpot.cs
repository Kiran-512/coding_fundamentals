using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface
{
    public abstract class ParkingSpot
    {
        public ParkingRate ParkingRate { get; set; }
        public Vehicle Vehicle { get; set; }
        public abstract bool IsFree();

    }
}
