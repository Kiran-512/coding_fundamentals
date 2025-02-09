using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Receiver;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Command_Interface;


namespace All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Concrete_Command
{
    public class LightOffCommand : ICommand
    {
        Light _light;

        public LightOffCommand(Light _light)
        {
            this._light = _light;
        }
        public void Execute()
        {
            _light.TurnOff();
        }

        public void Undo()
        {
            _light.TurnOn();
        }
    }
}
