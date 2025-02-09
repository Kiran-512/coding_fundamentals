using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Command_Interface;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.LightOnOff.Receiver;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Command_Pattern.LightOnOff.Command
{
    public class FanOnCommand : ICommand
    {
        private readonly Fan _fan;
        public FanOnCommand(Fan fan) => _fan = fan;

        public void Execute() => _fan.Start();
        public void Undo() => _fan.Stop();
    }
}
