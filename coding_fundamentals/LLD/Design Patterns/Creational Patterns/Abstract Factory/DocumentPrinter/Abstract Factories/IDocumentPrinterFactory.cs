using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Abstract_Factories
{
    public interface IDocumentPrinterFactory
    {
        IDocument CreateDocument(); // Method to create a document
        IPrinter CreatePrinter(IPrinterMaterialFactory _printerMaterial); // Method to create a printer
    }
}
