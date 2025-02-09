using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.AbstractMediator;
using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.Colleague;
using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.Infrstructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.ConcreteMediator
{
    public class AirTrafficControlTower : IAirTrafficControl
    {
        private List<Aircraft> _aircrafts = new List<Aircraft>();
        private Runway _runway;
        public AirTrafficControlTower(Runway runway)
        {
            _runway = runway;
        }
        public void RegisterAircraft(Aircraft aircraft)
        {
            _aircrafts.Add(aircraft);
        }
        public void CheckLandingApproval(Aircraft aircraft)
        {
            Console.WriteLine($"{aircraft.CallSign} is requesting to land.");

            // Check if runway is available
            if (IsRunwayAvailable(aircraft))
            {
                Console.WriteLine($"Runway is clear. {aircraft.CallSign}, you are cleared to land.");
                Thread.Sleep(5000);
                aircraft.Land();
            }
            else
            {
                Console.WriteLine($"Runway is busy. {aircraft.CallSign}, please hold your position.");
            }
        }
        private bool IsRunwayAvailable(Aircraft aircraft)
        {
            if (_runway.IsOccupied)
            {
                return false;
            }
            return true;
        }
        public void NotifyAircraftLanded(Aircraft aircraft)
        {
            Console.WriteLine($"{aircraft.CallSign} has landed.");
            _runway.IsOccupied = false; // Mark the runway as available
            _aircrafts.Remove(aircraft);
            NotifyRunwayAvailability();
        }
        private void NotifyRunwayAvailability()
        {
            foreach (var aircraft in _aircrafts)
            {
                aircraft.NotifyRunwayAvailable();
            }
        }
    }
}
