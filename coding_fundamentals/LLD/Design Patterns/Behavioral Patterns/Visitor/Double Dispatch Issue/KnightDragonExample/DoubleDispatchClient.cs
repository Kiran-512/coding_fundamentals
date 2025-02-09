using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Visitor.Double_Dispatch_Issue.KnightDragonExample
{
    public class DoubleDispatchClient
    {

        public static void main()
        {
            Entity knight = new Knight();
            Entity dragon = new Dragon();

            knight.Interact(dragon);
            dragon.Interact(knight);
        }
    }
}
