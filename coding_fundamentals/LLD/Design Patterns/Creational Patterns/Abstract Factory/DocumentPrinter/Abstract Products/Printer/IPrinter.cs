using All.Design.Patterns.Creational_Patterns.Factory.AbstractProduct;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts
{
    public interface IPrinter
    {
        void Print(IDocument document); // Method to print a document
        void CheckInk(); // Method to check ink level
        void CheckPaper(); // Method to check paper availability
        void AddCustomisedPaper(IPaper paper); // Method to add customised paper
        void AddCustomisedLink(IInk ink); // Method to add customised ink
    }
}
