using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Constants;
using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Models
{
    public class CardPayment : Payment
    {
        public String NameOnCard { get; set; }
        public enumCardType CardType { get; set; }
        public override void InititaeTransaction()
        {

        }
    }
}
