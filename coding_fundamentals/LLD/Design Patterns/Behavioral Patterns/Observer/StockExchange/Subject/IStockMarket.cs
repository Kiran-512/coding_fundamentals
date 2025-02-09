using All.Design.Patterns.Behavioral_Patterns.Observer.StockExchange.Observer;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Observer.StockExchange.Subject
{
    public interface IStockMarket
    {
        void RegisterAnalyst(IStockAnalyst analyst);
        void RemoveAnalyst(IStockAnalyst analyst);
        void NotifyAnalysts();
    }
}
