using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.Colleague;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.AbstractMediator
{
    public interface IAirTrafficControl
    {
        void RegisterAircraft(Aircraft aircraft);
        void CheckLandingApproval(Aircraft aircraft);
        void NotifyAircraftLanded(Aircraft aircraft);
    }
}
