using All.Design.Patterns.Behavioral_Patterns.Interpreter.AbstractInterpreter;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Interpreter.TerminalExpression
{
    public class NumberExpression : IExpression
    {
        private int _number { get; set; }
        public NumberExpression(int number)
        {
            _number = number;
        }
        public int Interpret()
        {
            return _number;
        }
    }
}
