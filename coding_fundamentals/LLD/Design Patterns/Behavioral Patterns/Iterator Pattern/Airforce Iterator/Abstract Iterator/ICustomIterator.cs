using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Abstract_AggregateElements;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Airforce_Iterator.Abstract_Iterator
{
    public interface ICustomIterator
    {
        IAircraft Next();
        bool HasNext();
    }
}
