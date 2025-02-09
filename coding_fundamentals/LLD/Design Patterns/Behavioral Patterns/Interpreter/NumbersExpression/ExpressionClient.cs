using All.Design.Patterns.Behavioral_Patterns.Interpreter.AbstractInterpreter;
using All.Design.Patterns.Behavioral_Patterns.Interpreter.Non_TerminalExpression;
using All.Design.Patterns.Behavioral_Patterns.Interpreter.TerminalExpression;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Interpreter
{
    public class ExpressionClient
    {
        public static void main()
        {
            Console.WriteLine("Enter : ");//1 + 1 - 1 + 45
            var inputExpression = Console.ReadLine();

            string[] tokens = inputExpression.Split(' ');

            IExpression leftExpression = new NumberExpression(int.Parse(tokens[0]));

            for (int i = 1; i < tokens.Length; i += 2)
            {
                string operation = tokens[i];

                int number = int.Parse(tokens[i + 1]);
                IExpression rightExpression = new NumberExpression(number);

                switch (operation)
                {
                    case "+":
                        leftExpression = new AddExpression(leftExpression, rightExpression);
                        break;
                    case "-":
                        leftExpression = new SubtractExpression(leftExpression, rightExpression);
                        break;
                    default:
                        break;
                }
            }

            int result = leftExpression.Interpret();
            Console.WriteLine($"{inputExpression} = {result}");
        }
    }
}