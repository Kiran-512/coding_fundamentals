using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Abstract_Factories;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Factories.DocumentPrinterFactory;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Factories.PrinterMaterialFactory;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Products;
using All.Design.Patterns.Creational_Patterns.Abstract_Factory.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.Client
{
    public static class AbstractFactoryClient
    {
        public static void main()
        {

            //code for Word Laser printer
            //Get the WordLaserPrinter document
            IDocumentPrinterFactory factory = new WordLaserPrinterFactory();
            IDocument document = factory.CreateDocument();

            //Load the material for WordLaser Printer
            IPrinterMaterialFactory _printerMaterial = new LaserPrinterMaterialFactory();
            IPrinter printer = factory.CreatePrinter(_printerMaterial);
            document.SetContent("Hey there! its great to code abstract factory pattern for WORD file with Laser Printer, with the default Laser printer material!");

            //adding customised papers
            printer.AddCustomisedPaper(new A4Paper());
            printer.AddCustomisedLink(new BlackInk());
            printer.Print(document);


            Helper.CheckPrinterStatus(printer);
            printer.PrintDocument(document);


            //code for PDF Injector printer
            factory = new PDFInkjetPrinterFactory();
            document = factory.CreateDocument();

            _printerMaterial = new InkjetPrinterMaterialFactory();
            printer = factory.CreatePrinter(_printerMaterial);

            document.SetContent("Hey there! its great to code abstract factory pattern, PDF file with Inkjet Printer, with the default Inkjet printer material!");

            //adding customised papers
            printer.AddCustomisedPaper(new A4Paper());
            printer.AddCustomisedLink(new BlackInk());
            printer.Print(document);

            Helper.CheckPrinterStatus(printer);
            printer.PrintDocument(document);
        }
    }
}
/*
Paper added to Laser Printer: A4
Ink added to Laser Printer: Black
Checking ink level in Laser Printer
Checking paper availability in Laser Printer
Printing Word Document: Hey there! its great to code abstract factory pattern for WORD file with Laser Printer, with the default Laser printer material!!
Checking ink level in Laser Printer
Checking paper availability in Laser Printer
Checking ink level in Laser Printer
Checking paper availability in Laser Printer
Printing Word Document: Hey there! its great to code abstract factory pattern for WORD file with Laser Printer, with the default Laser printer material!!
Paper added to Inkjet Printer: A4
Ink added to Inkjet Printer: Black
Checking ink level in Inkjet Printer
Checking paper availability in Inkjet Printer
Printing PDF Document: Hey there! its great to code abstract factory pattern, PDF file with Inkjet Printer, with the default Inkjet printer material!!
Checking ink level in Inkjet Printer
Checking paper availability in Inkjet Printer
Checking ink level in Inkjet Printer
Checking paper availability in Inkjet Printer
Printing PDF Document: Hey there! its great to code abstract factory pattern, PDF file with Inkjet Printer, with the default Inkjet printer material!!
Hello World!
 */