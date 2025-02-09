using All.Design.Patterns.Behavioral_Patterns.Observer.StockExchange.Subject;
using All.Design.Patterns.Behavioral_Patterns.Observer.StockExchange.Observer;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Observer.StockExchange.ConcreteSubject
{
    public class StockMarket : IStockMarket
    {
        private List<IStockAnalyst> _analysts = new List<IStockAnalyst>();
        private Dictionary<string, float> _stockPrices = new Dictionary<string, float>();

        public void RegisterAnalyst(IStockAnalyst analyst)
        {
            _analysts.Add(analyst);
        }

        public void RemoveAnalyst(IStockAnalyst analyst)
        {
            _analysts.Remove(analyst);
        }

        public void NotifyAnalysts()
        {
            foreach (var analyst in _analysts)
            {
                analyst.ReceiveUpdate(_stockPrices);
            }
        }
        public void SetStockPrice(string stockSymbol, float price)
        {
            _stockPrices[stockSymbol] = price;
            NotifyAnalysts();
        }

    }
}
