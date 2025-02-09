using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Abstract_AggregateElements;
using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Iterator;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Abstract_Aggregate
{
    public interface IAirforce
    {
        void Add(IAircraft aircraft);
        AirForceIterator GetIterator();
    }
}
