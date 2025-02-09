using All.Design.Patterns.Behavioral_Patterns.Strategy.Context;
using All.Design.Patterns.Behavioral_Patterns.Strategy.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Strategy
{
    public class StrategyClient
    {
        static void Main1(string[] args)
        {
            // Payment using Credit Card
            PaymentContext paymentContext = new PaymentContext(new CreditCardPayment());
            paymentContext.MakePayment(150.75);

            // Switching to PayPal payment
            paymentContext.SetPaymentStrategy(new PayPalPayment());
            paymentContext.MakePayment(89.99);
        }
    }
}
