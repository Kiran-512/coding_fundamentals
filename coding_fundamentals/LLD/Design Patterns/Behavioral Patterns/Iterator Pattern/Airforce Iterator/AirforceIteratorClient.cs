using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Abstract_AggregateElements;
using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator
{
    public class AirforceIteratorClient
    {
        public void Main()
        {
            Airforce airforce = new Airforce();
            var iterator = airforce.GetIterator();
            while (iterator.HasNext())
            {
                IAircraft aircraft = iterator.Next();
            }
        }
    }
}
