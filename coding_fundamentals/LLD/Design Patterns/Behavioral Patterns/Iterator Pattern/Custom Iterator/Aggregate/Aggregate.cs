using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Abstract_Aggregate;
using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Abstract_Iterator;
using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Iterator;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Aggregate
{
    public class Aggregate<T> : IAggregate<T>
    {
        private readonly IList<T> _collection = new List<T>();
        public void AddItem(T item)
        {
            _collection.Add(item);
        }
        public IIterator<T> CreateIterator()
        {
            return new Iterator<T>(_collection);
        }
    }
}
