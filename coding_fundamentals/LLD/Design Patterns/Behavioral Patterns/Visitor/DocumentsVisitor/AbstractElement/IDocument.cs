using All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.AbstractVisitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.AbstractElement
{
    public interface IDocument
    {
        void Accept(IDocumentVisitor visitor);

    }
}
