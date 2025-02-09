using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.Infrstructure
{
    public class Runway
    {
        public string Name { get; private set; }
        public bool IsOccupied { get; set; }

        public Runway(string name)
        {
            Name = name;
            IsOccupied = false;
        }
    }
}
