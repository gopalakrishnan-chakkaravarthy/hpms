using System.Collections.Generic;
using System.Linq;

namespace LabManagement.System.Common
{
    public  class BaseTaxCalculator
    {
        private readonly List<double?> taxValues;
        public double SELLINGPRICE { get; set; }
        public double TAXAMOUNT { get; set; }
        public BaseTaxCalculator(List<double?> taxValues)
        {
            this.taxValues = taxValues;
        }
        public void CalculateTax()
        {
            if (taxValues == null || !taxValues.Any())
            {
                return;
            }
            var totalTax = taxValues.Sum(x => x.Value);
            TAXAMOUNT = (SELLINGPRICE * totalTax) / 100;
        }
    }
}