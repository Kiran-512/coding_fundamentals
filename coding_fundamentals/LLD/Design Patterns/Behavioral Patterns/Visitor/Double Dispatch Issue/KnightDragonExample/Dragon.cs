using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Visitor.Double_Dispatch_Issue.KnightDragonExample
{
    public class Dragon : Entity
    {
        public override void Interact(Entity other)
        {
            other.InteractWith(this);
        }

        public override void InteractWith(Knight knight)
        {
            Console.WriteLine("Dragon burns Knight");
        }

        public override void InteractWith(Dragon dragon)
        {
            Console.WriteLine("Dragon meets Dragon");
        }
    }
}
