using All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Iterator_Pattern
{
    public class IteratorClient
    {
        public static void main()
        {
            var aggregate = new Aggregate<string>();
            //aggregate.AddItem("Item 1");
            //aggregate.AddItem("Item 2");
            //aggregate.AddItem("Item 3");

            var iterator = aggregate.CreateIterator();
            //Console.WriteLine(iterator.Current); //Exception here 

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Current);
                iterator.Next();
            }
        }
    }
}
