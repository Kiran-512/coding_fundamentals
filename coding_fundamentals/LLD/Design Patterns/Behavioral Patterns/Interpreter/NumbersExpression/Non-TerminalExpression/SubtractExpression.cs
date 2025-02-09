using All.Design.Patterns.Behavioral_Patterns.Interpreter.AbstractInterpreter;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Interpreter.Non_TerminalExpression
{
    public class SubtractExpression : IExpression
    {
        private IExpression _leftExpression;
        private IExpression _rightExpression;
        public SubtractExpression(IExpression left, IExpression right)
        {
            _leftExpression = left;
            _rightExpression = right;
        }
        public int Interpret()
        {
            return _leftExpression.Interpret() - _rightExpression.Interpret();
        }
    }
}
