using All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.Element;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.AbstractVisitor
{
    public interface IDocumentVisitor
    {
        void Visit(WordDocument document);
        void Visit(PDFDocument document);
    }
}
