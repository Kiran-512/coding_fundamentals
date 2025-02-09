using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Creational_Patterns.Factory.AbstractProduct;

namespace All.Design.Patterns.Creational_Patterns.Factory.Product
{
    public class PdfDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening PDF Document");
        public void Save() => Console.WriteLine("Saving PDF Document");
        public void Close() => Console.WriteLine("Closing PDF Document");
    }
}
