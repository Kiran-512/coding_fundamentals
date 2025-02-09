using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Products
{
    public class PDFDocument : IDocument
    {
        private string _content;

        public void Print()
        {
            // Implementation for printing a PDF document
            Console.WriteLine("Printing PDF Document: " + _content);
        }

        public string GetContent()
        {
            return _content;
        }

        public void SetContent(string content)
        {
            _content = content;
        }
    }
}
