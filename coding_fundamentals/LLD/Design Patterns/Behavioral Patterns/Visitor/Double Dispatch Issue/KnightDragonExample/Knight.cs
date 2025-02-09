using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Visitor.Double_Dispatch_Issue.KnightDragonExample
{
    public class Knight : Entity
    {
        public override void Interact(Entity other)
        {
            other.InteractWith(this);
        }

        public override void InteractWith(Knight knight)
        {
            Console.WriteLine("Knight interacts with Knight");
        }

        public override void InteractWith(Dragon dragon)
        {
            Console.WriteLine("Knight slays Dragon");
        }
    }
}
