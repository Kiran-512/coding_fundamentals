using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Abstract_Factory.AbstractProducts
{
    public interface IDocument
    {
        void Print(); // Method to print the document
        String GetContent(); // Method to get the content of the document
        void SetContent(String content);  // Method to set the content of the document
    }
}
