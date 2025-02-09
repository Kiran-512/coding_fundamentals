using All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.AbstractElement;
using All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.AbstractVisitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.Element
{
    public class PDFDocument : IDocument
    {
        public string Content { get; set; }

        public void Accept(IDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
