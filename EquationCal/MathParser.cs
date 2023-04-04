using MathNet.Numerics;
using NCalc;
using System;
using System.Threading.Tasks;

namespace EquationCal.Pages
{
    public class MathParser
    {
        public async Task<double> Parse(string expression)
        {
            // Evaluate expression using NCalc
            var expr = new Expression(expression);
            var result = expr.Evaluate();

            if (result == null)
                throw new ArgumentException("Expression could not be evaluated as a number.");
            
            return await Task.FromResult(Convert.ToDouble(result));
        }
    }
}