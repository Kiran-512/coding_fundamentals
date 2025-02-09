using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Behavioral_Patterns.CoR.Handler;

namespace All.Design.Patterns.Behavioral_Patterns.CoR.ConcreteHandler
{
    public class MidLevelSupport : SupportHandler
    {
        private int midLevelCodeStart = 2;
        private int midLevelCodeEnd = 5;
        public override void HandleRequest(string request, int severity)
        {
            if (severity > midLevelCodeStart && severity < midLevelCodeEnd)
            {
                //TODO : logic to handle that request
                Console.WriteLine($"Mid Level : {request}");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request, severity);
            }
        }
    }
}
