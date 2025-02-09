using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Receiver
{
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light Turned On");
        }
        public void TurnOff()
        {
            Console.WriteLine("Light Turned Off");
        }
    }
}
