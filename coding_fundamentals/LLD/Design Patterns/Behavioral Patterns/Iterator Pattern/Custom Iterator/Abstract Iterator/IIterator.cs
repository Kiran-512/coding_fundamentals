using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Abstract_Iterator
{
    public interface IIterator<T>
    {
        T Current { get; }
        bool HasNext();
        void Next();
    }
}
