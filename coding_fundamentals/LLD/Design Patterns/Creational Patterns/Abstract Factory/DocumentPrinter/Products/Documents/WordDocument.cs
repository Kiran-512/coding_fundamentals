using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Products
{
    public class WordDocument : IDocument
    {
        private string _content;

        public void Print()
        {
            // Implementation for printing a Word document
            Console.WriteLine("Printing Word Document: " + _content);
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
