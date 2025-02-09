using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface.Payment
{
    public abstract class Payment
    {
        public double Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TxnId { get; set; }
        public abstract void InititaeTransaction();
    }
}
