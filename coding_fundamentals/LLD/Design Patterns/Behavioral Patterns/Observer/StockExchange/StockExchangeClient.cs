using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.Behavioral_Patterns.Observer.StockExchange.ConcreteObserver;
using All.Design.Patterns.Behavioral_Patterns.Observer.StockExchange.ConcreteSubject;
using All.Design.Patterns.Behavioral_Patterns.Observer.StockExchange.Observer;

namespace All.Design.Patterns.Behavioral_Patterns.Observer.StockExchangeClient
{
    public class StockExchangeClient
    {
        public static void main()
        {
            StockMarket stockMarket = new StockMarket();
            IStockAnalyst analyst1 = new StockAnalyst("Alice");
            IStockAnalyst analyst2 = new StockAnalyst("Bob");

            stockMarket.RegisterAnalyst(analyst1);
            stockMarket.RegisterAnalyst(analyst2);

            stockMarket.SetStockPrice("GOGL",356.25F);
            stockMarket.SetStockPrice("MICRSFT", 456.235F);
            stockMarket.SetStockPrice("MET",5468.54F);


        }
    }
}
