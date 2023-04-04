using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EquationCal.Pages
{
    public class CalculatorModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public CalculatorModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        [Required]
        public string Equation { get; set; }

        [BindProperty]
        [Required]
        public double? XValue { get; set; }

        public double? YValue { get; set; }

        public async Task OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            try
            {
                // Evaluate equation and solve for YValue
                var parser = new MathParser();
                YValue = parser.Parse(Equation.ToLower().Replace("x", XValue.ToString())).Result;

                // Save calculation to database
                var calculation = new Calculations
                {
                    Equation = Equation,
                    XValue = (double)XValue,
                    YValue = (double)YValue,
                    CalculationDate = DateTime.Now
                };
                _dbContext.Calculations.Add(calculation);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }

    }
}
