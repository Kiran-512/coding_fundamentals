using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts
{
    public interface IPaper
    {
        String GetSize(); // Method to get the size of the paper
        void SetSize(String size); // Method to set the size of the paper
        String GetPaperType(); // Method to get the type of the paper
        void SetPaperType(String type); // Method to set the type of the paper
    }
}
