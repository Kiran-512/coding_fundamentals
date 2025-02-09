using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Command_Interface;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Receiver;

namespace All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Concrete_Command
{
    public class LightOnCommand : ICommand
    {
        Light _light;

        public LightOnCommand(Light _light)
        {
            this._light = _light;
        }
        public void Execute()
        {
            _light.TurnOn();
        }

        public void Undo()
        {
            _light.TurnOff();
        }
    }
}
