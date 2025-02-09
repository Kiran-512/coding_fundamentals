using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Products
{
    public class LetterPaper : IPaper
    {
        private string _size = "Letter";
        private string _type = "Matte";
        public string GetSize()
        {
            return _size;
        }

        public void SetSize(string size)
        {
            _size = size;
        }

        public string GetPaperType()
        {
            return _type;
        }

        public void SetPaperType(string type)
        {
            _type = type;
        }
    }
}
