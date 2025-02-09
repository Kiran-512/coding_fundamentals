using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Models
{
    public class ParkingLotSystem
    {
        public String Name { get; set; }
        public String Address { get; set; }

        private int compactSpotCount;
        private int largeSpotCount;
        private int motorbikeSpotCount;
        private int electricSpotCount;
        private const int maxCompactCount = 100;
        private const int maxLargeCount = 100;
        private const int maxMotorbikeCount = 100;

        private Dictionary<String, Entrance> entrancePanels;
        private Dictionary<String, Exit> exitPanels;

        private Dictionary<String, ParkingTicket> activeTickets;    // all active parking tickets, identified by their ticketNumber




        private static ParkingLotSystem Instance = null;
        private static readonly object lockObj = new object();
        private const int MaxCapacity = 40000;
        private ParkingLotSystem()
        {
        }

        public static ParkingLotSystem GetInstance()
        {
            if (Instance == null)
            {
                lock (lockObj)
                {
                    if (Instance == null)
                    {
                        Instance = new ParkingLotSystem();
                    }
                }
            }
            //if (instance == null)
            //{
            //    Monitor.Enter(lockObj);
            //    try
            //    {

            //        if (instance == null)
            //        {
            //            instance = new ParkingLotSystem();
            //        }
            //    }
            //    finally {
            //        Monitor.Exit(lockObj);
            //    }
            //}
            return Instance;
        }
    }
}
