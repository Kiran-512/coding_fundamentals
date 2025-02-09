using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Abstract_Factories;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Factories.PrinterMaterialFactory
{
    public class LaserPrinterMaterialFactory : IPrinterMaterialFactory
    {
        public IPaper CreatePaper()
        {
            return new A4Paper();
        }

        public IInk CreateInk()
        {
            return new BlackInk();
        }
    }
}
