using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts
{
    public interface IInk
    {
        String GetColor(); // Method to get the color of the ink
        void SetColor(String color); // Method to set the color of the ink
        int GetLevel(); // Method to get the ink level
        void SetLevel(int level); // Method to set the ink level
    }
}
