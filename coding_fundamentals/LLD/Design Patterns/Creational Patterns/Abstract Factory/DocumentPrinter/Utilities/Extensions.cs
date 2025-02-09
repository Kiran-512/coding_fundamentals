using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Utilities
{
    public static class Extensions
    {
        public static void PrintDocument(this IPrinter printer, IDocument document)
        {
            printer.CheckInk();
            printer.CheckPaper();
            document.Print();
        }
    }
}
