using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Command_Interface
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
