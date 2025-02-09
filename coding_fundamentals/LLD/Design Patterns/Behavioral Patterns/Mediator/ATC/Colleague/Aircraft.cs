using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.AbstractMediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.Colleague
{
    public class Aircraft
    {
        private IAirTrafficControl _atc;
        public string CallSign { get; private set; }

        public Aircraft(IAirTrafficControl atc, string callSign)
        {
            CallSign = callSign;
            _atc = atc;
            _atc.RegisterAircraft(this);
        }
        public void RequestLanding()
        {
            _atc.CheckLandingApproval(this);
        }
        public void Land()
        {
            Console.WriteLine($"{CallSign} is landing.");
            Thread.Sleep(10000);
            _atc.NotifyAircraftLanded(this);
        }
        public void NotifyRunwayAvailable()
        {
            Console.WriteLine($"{CallSign} is notified: Runway is now available.");
        }
    }
}
