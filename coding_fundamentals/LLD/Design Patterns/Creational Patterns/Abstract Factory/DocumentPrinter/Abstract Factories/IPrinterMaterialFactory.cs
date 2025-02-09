using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Abstract_Factories
{
    public interface IPrinterMaterialFactory
    {
        IPaper CreatePaper(); // Method to create paper
        IInk CreateInk(); // Method to create ink
    }
}
