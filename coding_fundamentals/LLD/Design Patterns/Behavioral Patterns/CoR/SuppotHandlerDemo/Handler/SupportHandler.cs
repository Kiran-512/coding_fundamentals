using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.CoR.Handler
{
    public abstract class SupportHandler
    {
        protected SupportHandler _nextHandler;
        public void SetNextHandler(SupportHandler _next)
        {
            this._nextHandler = _next;
        }
        public abstract void HandleRequest(string request, int severity);
    }
}
