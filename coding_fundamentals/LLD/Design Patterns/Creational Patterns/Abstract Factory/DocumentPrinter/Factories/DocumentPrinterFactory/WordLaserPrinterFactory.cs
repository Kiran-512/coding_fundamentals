using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Abstract_Factories;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Factories.DocumentPrinterFactory
{
    public class WordLaserPrinterFactory : IDocumentPrinterFactory
    {
        public IDocument CreateDocument()
        {
            return new WordDocument();
        }

        public IPrinter CreatePrinter(IPrinterMaterialFactory _printerMaterial)
        {
            return new LaserPrinter(_printerMaterial);
        }
    }
}
