using All.Design.Patterns.Behavioral_Patterns.Strategy.StrategyInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Strategy.Strategies
{
    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay()
        {
            Console.WriteLine("PayPal payment");
        }
    }
}
