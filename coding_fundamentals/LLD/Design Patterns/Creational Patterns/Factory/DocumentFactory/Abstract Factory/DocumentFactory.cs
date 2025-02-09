using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Creational_Patterns.Factory.AbstractProduct;

namespace All.Design.Patterns.Creational_Patterns.Factory.FactoryMethod
{
    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }
}
