using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Abstract_Factories;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Factories.PrinterMaterialFactory
{
    public class InkjetPrinterMaterialFactory : IPrinterMaterialFactory
    {
        public IPaper CreatePaper()
        {
            return new LetterPaper();
        }

        public IInk CreateInk()
        {
            return new ColorInk();
        }
    }
}
