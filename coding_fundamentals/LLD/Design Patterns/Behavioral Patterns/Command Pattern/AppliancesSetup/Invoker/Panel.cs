using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Command_Interface;

namespace All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Invoker
{
    public class Panel
    {
        private ICommand _command;
        public Panel(ICommand _command)
        {
            this._command = _command;
        }
        public void PressButton()
        {
            _command.Execute();
        }
        public void PressUndo()
        {
            _command.Undo();
        }
    }
}
