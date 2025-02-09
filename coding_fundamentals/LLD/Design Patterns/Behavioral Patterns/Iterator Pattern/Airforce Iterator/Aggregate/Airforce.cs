using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Abstract_Aggregate;
using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Abstract_AggregateElements;
using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.AggregateElements;
using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Iterator;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Aggregate
{
    public class Airforce : IAirforce
    {
        public List<IAircraft> _aircrafts;

        public Airforce()
        {
            _aircrafts = new List<IAircraft>();
        }
        public void Add(IAircraft aircraft)
        {
            _aircrafts.Add(aircraft);
        }

        public List<IAircraft> GetHelis()
        {
            return new List<IAircraft>() { new Chopper() { id = 1 }, new Chopper() { id = 2 }, new Chopper() { id = 3 } };
        }

        public AirForceIterator GetIterator()
        {
            return new AirForceIterator(this);
        }

        public List<IAircraft> GetJets()
        {
            return new List<IAircraft>() { new FighterJet() { id = 1 }, new FighterJet() { id = 2 }, new FighterJet() { id = 3 } };
        }

        public IAircraft[] GetTransport()
        {
            return new IAircraft[] { new Transport() { id = 1 }, new Transport() { id = 2 }, new Transport() { id = 3 } };
        }
    }
}
