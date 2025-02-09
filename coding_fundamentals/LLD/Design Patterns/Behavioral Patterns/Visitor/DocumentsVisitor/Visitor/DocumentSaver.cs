using All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.AbstractVisitor;
using All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.Element;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.Visitor
{
    public class DocumentSaver : IDocumentVisitor
    {
        public void Visit(WordDocument document)
        {
            Console.WriteLine("Saving Word Document");
        }

        public void Visit(PDFDocument document)
        {
            Console.WriteLine("Saving PDF Document");
        }
    }
}
