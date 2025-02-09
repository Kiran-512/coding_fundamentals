using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Command_Pattern.LightOnOff.Receiver
{
    public class Receivers
    {
    }
    public class Fan
    {
        public void Start() => Console.WriteLine("Fan is ON");
        public void Stop() => Console.WriteLine("Fan is OFF");
    }

    public class MusicSystem
    {
        public void Play() => Console.WriteLine("Playing Music");
        public void Stop() => Console.WriteLine("Stopping Music");
    }
}
