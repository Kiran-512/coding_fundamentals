using All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.AbstractElement;
using All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.AbstractVisitor;
using All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.Element;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.Visitor
{
    public class DocumentPrinter : IDocumentVisitor
    {
        public void Visit(WordDocument document)
        {
            Console.WriteLine("Printing the Word Document");
        }

        public void Visit(PDFDocument document)
        {
            Console.WriteLine("Printing PDF Document");
        }
    }
}
