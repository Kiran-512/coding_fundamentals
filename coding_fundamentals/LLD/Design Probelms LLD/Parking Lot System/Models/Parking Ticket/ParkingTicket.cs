using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Constants;
using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface;
using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Models
{
    public class ParkingTicket
    {
        public int TicketNo { get; set; }
        public DateTime Entry { get; set; }
        public DateTime Exit { get; set; }
        public double Amount { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public Payment Payment { get; set; }
        public Vehicle Vehicle { get; set; }
        public Entrance Entrance { get; set; }
        public Exit ExitPanel { get; set; }
    }
}
