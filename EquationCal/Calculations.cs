using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

namespace EquationCal
{
    public class Calculations
    {
        [Key]
        public int CalculationId { get; set; }
        public string Equation { get; set; }
        public double XValue { get; set; }
        public double YValue { get; set; }
        public DateTime CalculationDate { get; set; }
    }
}
