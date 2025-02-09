using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Models
{
    public class Mototrcycle : ParkingSpot
    {
        public override bool IsFree()
        {
            return true;
        }
    }
}
