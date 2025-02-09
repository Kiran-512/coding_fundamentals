using All.Design.Patterns.Behavioral_Patterns.Observer.StockExchange.Observer;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Observer.StockExchange.ConcreteObserver
{
    public class StockAnalyst : IStockAnalyst
    {
        private string _name;

        public StockAnalyst(string name)
        {
            _name = name;
        }
        public void ReceiveUpdate(Dictionary<string, float> stockPrices)
        {
            Console.WriteLine($"Analyst {_name} received stock price updates:");
            foreach (var stock in stockPrices)
            {
                Console.WriteLine($"Stock: {stock.Key}, Price: {stock.Value}");
            }
        }
    }
}
