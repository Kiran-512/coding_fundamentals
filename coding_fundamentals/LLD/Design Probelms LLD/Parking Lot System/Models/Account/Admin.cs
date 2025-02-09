using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Models
{
    public class Admin : Account
    {
        public override void ResetPassword()
        {
            Console.WriteLine("Password Reset Done");
        }
        public void AddParkingSpot(ParkingSpot parkingSpot)
        {
            Console.WriteLine("Parking spot added");
        }
        public void AddEntrance(Entrance entry)
        {
            Console.WriteLine("Entrance spot added");
        }
        public void AddExit(Exit exit)
        {
            Console.WriteLine("EXIT spot added");
        }
        public void AddDisplayBoard(DisplayBoard board)
        {
            Console.WriteLine("DB spot added");
        }



    }
}
