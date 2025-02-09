using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Behavioral_Patterns.CoR.ConcreteHandler;

namespace All.Design.Patterns.Behavioral_Patterns.CoR.Client
{
    public class Client
    {
        public static void main()
        {
            LowLevelSupport lowerHandler = new LowLevelSupport();
            MidLevelSupport midHandler = new MidLevelSupport();
            HighLevelSupport highHandler = new HighLevelSupport();

            lowerHandler.SetNextHandler(midHandler);
            midHandler.SetNextHandler(highHandler);

            //lowerHandler.HandleRequest("Password reset", 1);
            lowerHandler.HandleRequest("Software installation issue", 3);
            //lowerHandler.HandleRequest("Server outage", 7);
        }
    }
}
