using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.Colleague;
using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.ConcreteMediator;
using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.Infrstructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Mediator.ATC
{
    public class ATCHost
    {
        public static void main()
        {
            var runway = new Runway("Runway 27");
            var atcTower = new AirTrafficControlTower(runway);

            var aircraft1 = new Aircraft(atcTower, "Flight A123");
            var aircraft2 = new Aircraft(atcTower, "Flight B456");
            var aircraft3 = new Aircraft(atcTower, "Flight C556");
            var aircraft4 = new Aircraft(atcTower, "Flight D656");

            aircraft1.RequestLanding();
            aircraft2.RequestLanding();
            aircraft3.RequestLanding();
            aircraft4.RequestLanding();
        }
    }
}
/*
 Flight A123 is requesting to land.
Runway is clear. Flight A123, you are cleared to land.
Flight A123 is landing.
Flight A123 has landed.
Flight B456 is notified: Runway is now available.
Flight C556 is notified: Runway is now available.
Flight D656 is notified: Runway is now available.
Flight B456 is requesting to land.
Runway is clear. Flight B456, you are cleared to land.
Flight B456 is landing.
Flight B456 has landed.
Flight C556 is notified: Runway is now available.
Flight D656 is notified: Runway is now available.
Flight C556 is requesting to land.
Runway is clear. Flight C556, you are cleared to land.
Flight C556 is landing.
Flight C556 has landed.
Flight D656 is notified: Runway is now available.
Flight D656 is requesting to land.
Runway is clear. Flight D656, you are cleared to land.
Flight D656 is landing.
Flight D656 has landed.
 */