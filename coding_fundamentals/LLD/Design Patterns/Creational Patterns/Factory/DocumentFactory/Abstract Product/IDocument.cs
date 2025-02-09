using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Factory.AbstractProduct
{
    public interface IDocument
    {
        void Open();
        void Save();
        void Close();
    }
}
