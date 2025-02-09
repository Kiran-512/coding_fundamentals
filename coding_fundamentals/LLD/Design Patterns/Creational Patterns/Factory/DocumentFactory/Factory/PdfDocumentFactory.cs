using All.Design.Patterns.Creational_Patterns.Factory.AbstractProduct;
using All.Design.Patterns.Creational_Patterns.Factory.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Factory.FactoryMethod
{
    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }
}
