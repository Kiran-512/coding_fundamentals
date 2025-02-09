using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Utilities
{
    public static class Helper
    {
        public static void CheckPrinterStatus(IPrinter printer)
        {
            printer.CheckInk();
            printer.CheckPaper();
        }
    }
}
