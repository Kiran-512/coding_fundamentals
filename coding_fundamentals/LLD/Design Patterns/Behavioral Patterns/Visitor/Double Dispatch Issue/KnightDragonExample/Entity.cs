using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Visitor.Double_Dispatch_Issue.KnightDragonExample
{
    public class Entity
    {
        public virtual void Interact(Entity other)
        {
            other.InteractWith(this);
        }
        public virtual void InteractWith(Entity entity)
        {
            Console.WriteLine("Entity interacts with Entity");
        }
        public virtual void InteractWith(Knight knight)
        {
            Console.WriteLine("Entity interacts with Knight");
        }

        public virtual void InteractWith(Dragon dragon)
        {
            Console.WriteLine("Entity interacts with Dragon");
        }
    }
}
