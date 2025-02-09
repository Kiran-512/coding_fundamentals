using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Abstract_Iterator;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Abstract_Aggregate
{
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }
}
