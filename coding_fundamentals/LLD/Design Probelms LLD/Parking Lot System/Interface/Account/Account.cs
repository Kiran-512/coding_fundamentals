using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.Colleague;
using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface
{
    public abstract class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public User User { get; set; }
        public abstract void ResetPassword();
    }
}
