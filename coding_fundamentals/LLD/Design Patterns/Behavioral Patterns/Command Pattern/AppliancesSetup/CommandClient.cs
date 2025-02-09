using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Invoker;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Receiver;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Command_Interface;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Concrete_Command;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.LightOnOff.Command;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.LightOnOff.Receiver;

namespace All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Client
{
    public class CommandClient
    {
        public static void main()
        {
            //Light livingRoomLight = new Light();
            //ICommand lightOnCommand = new LightOnCommand(livingRoomLight);
            //ICommand lightOffCommand = new LightOffCommand(livingRoomLight);

            //Panel panel = new Panel(lightOnCommand);
            //panel.PressButton();

            //panel = new Panel(lightOffCommand);
            //panel.PressButton();

            //panel.PressUndo();

            // Create Receivers
            Light light = new Light();
            Fan fan = new Fan();
            MusicSystem musicSystem = new MusicSystem();

            // Create Commands
            ICommand lightOnCommand = new LightOnCommand(light);
            ICommand fanOnCommand = new FanOnCommand(fan);
            ICommand musicPlayCommand = new MusicPlayCommand(musicSystem);

            // Invoker
            Panel remote = new Panel(lightOnCommand);

            // Control Light
            //remote.SetCommand(lightOnCommand);
            remote.PressButton();
            remote.PressUndo();

            // Control Fan
            remote = new Panel(fanOnCommand);
            //remote.SetCommand(fanOnCommand);
            remote.PressButton();

            // Control Music System
            //remote.SetCommand(musicPlayCommand);
            remote = new Panel(musicPlayCommand);
            remote.PressButton();
        }
    }
}
/*
The Command Pattern achieves decoupling by separating the 
Invoker (the object that initiates an operation) 
from the Receiver (the object that performs the operation). 

The Command serves as a middleman, encapsulating the operation and its details. 
This way, the invoker does not need to know how the 
operation is executed or even who executes it.


//Client will interact wit the panel which will trigger the commmand, which s beng abstract will invoke the particular command of a reciver
*/