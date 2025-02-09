using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Behavioral_Patterns.CoR.Handler;

namespace All.Design.Patterns.Behavioral_Patterns.CoR.ConcreteHandler
{
    public class LowLevelSupport : SupportHandler
    {
        private int lowLevelCode = 2;
        public override void HandleRequest(string request, int severity)
        {
            if (severity <= lowLevelCode)
            {
                //TODO : Logic for low level support 
                Console.WriteLine($"Low Level : {request}");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request, severity);
            }

        }
    }
}
