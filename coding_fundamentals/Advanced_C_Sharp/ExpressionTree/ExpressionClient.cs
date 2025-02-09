using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace All.Design.Patterns.Advanced_C_Sharp.ExpressionTree
{
    public class ExpressionClient
    {

        public static void Basic()
        {
            Func<int, bool> func = i => i > 5;

            Expression<Func<int, bool>> func1 = i => i > 5;

            Expression<Func<int, bool>> expression = Expression.Lambda<Func<int, bool>>(
                Expression.GreaterThan(
                    Expression.Parameter(typeof(int), "i"),
                    Expression.Constant(5)
                ),
                new ParameterExpression[] { Expression.Parameter(typeof(int), "i") }
            );

            ParameterExpression pexp = Expression.Parameter(typeof(int), "i");
            ConstantExpression xexp = Expression.Constant(5);
            ParameterExpression[] paramsExp = new ParameterExpression[] { Expression.Parameter(typeof(int), "i") };
            Expression<Func<int, bool>> expression1 = Expression.Lambda<Func<int, bool>>(
                Expression.GreaterThan(
                    pexp, xexp
                ), paramsExp);

            expression1.Compile();
        }
        public static void Main1()
        {
            Basic();
        }
    }
}
