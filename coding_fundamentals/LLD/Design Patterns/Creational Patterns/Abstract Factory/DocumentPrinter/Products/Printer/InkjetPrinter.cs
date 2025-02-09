using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Abstract_Factories;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Products
{
    public class InkjetPrinter : IPrinter
    {
        private IPaper _paper;
        private IInk _ink;

        public InkjetPrinter(IPrinterMaterialFactory _printerMaterial)
        {
            _paper = _printerMaterial.CreatePaper();
            _ink = _printerMaterial.CreateInk();
        }
        public void Print(IDocument document)
        {
            CheckInk();
            CheckPaper();
            document.Print();
        }
        public void CheckInk()
        {
            Console.WriteLine("Checking ink level in Inkjet Printer");
            // Implement ink check logic
        }

        public void CheckPaper()
        {
            Console.WriteLine("Checking paper availability in Inkjet Printer");
            // Implement paper check logic
        }

        public void AddCustomisedPaper(IPaper paper)
        {
            //Check if this paper is comptaible with this printer
            _paper = paper;
            Console.WriteLine("Paper added to Inkjet Printer: " + _paper.GetSize());
        }

        public void AddCustomisedLink(IInk ink)
        {
            //Check if this ink is comptaible with this printer
            _ink = ink;
            Console.WriteLine("Ink added to Inkjet Printer: " + _ink.GetColor());
        }
    }
}
