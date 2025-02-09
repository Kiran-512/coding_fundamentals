using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Abstract_Factories;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Factories.DocumentPrinterFactory
{
    public class PDFInkjetPrinterFactory : IDocumentPrinterFactory
    {
        IDocument IDocumentPrinterFactory.CreateDocument()
        {
            return new PDFDocument();
        }

        IPrinter IDocumentPrinterFactory.CreatePrinter(IPrinterMaterialFactory _printerMaterial)
        {
            return new InkjetPrinter(_printerMaterial);
        }
    }
}
