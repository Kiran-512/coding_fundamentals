using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Abstract_AggregateElements;
using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Abstract_Iterator;
using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Iterator
{
    public class AirForceIterator : ICustomIterator
    {
        private List<IAircraft> _jets;
        private List<IAircraft> _helis;
        private IAircraft[] _transports;
        private int jetPos { get; set; }
        private int heliPos { get; set; }
        private int transportPos { get; set; }
        public AirForceIterator(Airforce __airforce)
        {
            this._jets = __airforce.GetJets();
            this._helis = __airforce.GetHelis();
            this._transports = __airforce.GetTransport();
        }
        public bool HasNext()
        {
            return jetPos < _jets.Count || heliPos < _helis.Count || transportPos < _transports.Length;
        }

        public IAircraft Next()
        {
            if (jetPos < _jets.Count)
            {
                return _jets[jetPos++];
            }
            if (heliPos < _helis.Count)
            {
                return _helis[heliPos++];
            }
            if (transportPos < _transports.Length)
            {
                return _transports[transportPos++];
            }
            return null;//throw Exception
        }
    }
}
