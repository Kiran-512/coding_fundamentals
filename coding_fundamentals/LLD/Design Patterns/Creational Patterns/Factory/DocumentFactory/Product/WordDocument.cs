using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Creational_Patterns.Factory.AbstractProduct;
using All.Design.Patterns.Creational_Patterns.Factory.Product;

namespace All.Design.Patterns.Creational_Patterns.Factory.Product
{
    public class WordDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening Word Document");
        public void Save() => Console.WriteLine("Saving Word Document");
        public void Close() => Console.WriteLine("Closing Word Document");
    }
}
