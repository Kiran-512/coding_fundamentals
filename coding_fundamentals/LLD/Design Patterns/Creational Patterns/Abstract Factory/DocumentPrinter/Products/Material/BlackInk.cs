using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Products
{
    public class BlackInk : IInk
    {
        private string _color = "Black";
        private int _level = 100;
        public string GetColor()
        {
            return _color;
        }

        public void SetColor(string color)
        {
            _color = color;
        }

        public int GetLevel()
        {
            return _level;
        }

        public void SetLevel(int level)
        {
            _level = level;
        }
    }
}
