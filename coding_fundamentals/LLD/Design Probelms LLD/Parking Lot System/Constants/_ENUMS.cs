using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Constants
{
    public enum PaymentStatus
    {
        COMPLETE,
        PENDING,
        UNPAID,
        FAILED,
        REFUNDED
    }
    public enum AccountStatus
    {
        NONE,
        ACTIVE,
        CLOSED,
        BLACKLISTED
    }
    public enum TicketStatus
    {
        ACTIVE,
        PAID,
        LOST
    }
    public enum enumCardType
    {
        Credit,
        Debit,
        EMICard
    }
}
