using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Behavioral_Patterns.CoR.Handler;

namespace All.Design.Patterns.Behavioral_Patterns.CoR.ConcreteHandler
{
    public class HighLevelSupport : SupportHandler
    {
        private int highLevelCode = 5;
        public override void HandleRequest(string request, int severity)
        {
            if (severity >= highLevelCode)
            {
                //TODO : Logic for low level support 
                Console.WriteLine($"High Level : {request}");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request, severity);
            }
        }
    }
}
