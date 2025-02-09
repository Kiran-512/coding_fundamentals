using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Abstract_Iterator;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Iterator
{
    public class Iterator<T> : IIterator<T>
    {
        private readonly IList<T> _collection;
        private int _position = -1;

        public Iterator(IList<T> collection)
        {
            _collection = collection;
            _position = 0;
        }

        public T Current
        {
            get
            {
                if (_collection.Count == 0 || _position >= _collection.Count)
                    throw new InvalidOperationException("Collection is empty or iterator is out of bounds.");
                return _collection[_position];
            }
        }

        public bool HasNext() => _position <= _collection.Count - 1;

        public void Next()
        {
            _position++;
        }
    }
}
