using All.Design.Patterns.Behavioral_Patterns.Strategy.StrategyInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Strategy.Context
{
    public class PaymentContext
    {
        private IPaymentStrategy _strategy;

        public PaymentContext(IPaymentStrategy _strategy)
        {
            this._strategy = _strategy;
        }

        public void SetPaymentStrategy(IPaymentStrategy _strategy)
        {
            this._strategy = _strategy;
        }

        public void MakePayment(double amount)
        {
            _strategy.Pay();
        }
    }
}
