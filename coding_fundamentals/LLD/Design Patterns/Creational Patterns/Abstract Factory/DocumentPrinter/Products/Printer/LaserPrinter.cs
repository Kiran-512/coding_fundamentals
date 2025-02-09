using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Abstract_Factories;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Products
{
    public class LaserPrinter : IPrinter
    {
        private IPaper _paper;
        private IInk _ink;
        public LaserPrinter(IPrinterMaterialFactory _printerFactory)
        {
            _paper = _printerFactory.CreatePaper();
            _ink = _printerFactory.CreateInk();
        }

        public void Print(IDocument document)
        {
            CheckInk();
            CheckPaper();
            document.Print();
        }

        public void CheckInk()
        {
            Console.WriteLine("Checking ink level in Laser Printer");
            // Implement ink check logic
        }

        public void CheckPaper()
        {
            Console.WriteLine("Checking paper availability in Laser Printer");
            // Implement paper check logic
        }

        public void AddCustomisedPaper(IPaper paper)
        {
            //check if this paper is compatible with this printer
            _paper = paper;
            Console.WriteLine("Paper added to Laser Printer: " + _paper.GetSize());
        }

        public void AddCustomisedLink(IInk ink)
        {
            //check if this link is compatible with this printer
            _ink = ink;
            Console.WriteLine("Ink added to Laser Printer: " + _ink.GetColor());
        }
    }
}
