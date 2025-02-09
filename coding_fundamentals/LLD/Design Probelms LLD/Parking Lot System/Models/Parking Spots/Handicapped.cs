using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Models
{
    public class Handicapped : ParkingSpot
    {
        public override bool IsFree()
        {
            //logic to check if available or not
            return true;
        }
    }
}
