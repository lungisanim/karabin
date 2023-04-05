using MathNet.Numerics;
using Microsoft.Extensions.Logging;
using NCalc;
using System;
using System.Threading.Tasks;

namespace EquationCal.Pages
{
    public class MathParser
    {
        private readonly ILogger<IndexModel> _logger;
        public async Task<double> Parse(string expression)
        {
            var expr = new Expression(expression);
            var result = expr.Evaluate();

            if (result == null)
            {
                _logger.LogError("The result of the expression is null: Expression could not be evaluated as a number.");
                throw new ArgumentException("Expression could not be evaluated as a number.");
            }

            return await Task.FromResult(Convert.ToDouble(result));
        }
    }
}