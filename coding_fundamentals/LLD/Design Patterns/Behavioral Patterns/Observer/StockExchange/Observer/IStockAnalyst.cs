using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Observer.StockExchange.Observer
{
    public interface IStockAnalyst
    {
        void ReceiveUpdate(Dictionary<string, float> stockPrices);
    }
}
