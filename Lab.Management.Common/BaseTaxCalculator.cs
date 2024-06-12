using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Management.Common
{
    public class BaseTaxCalculator
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
        public double CalculateNetPriceAfterGst()
        {
            //GST Amount = Original Cost – (Original Cost * (100 / (100 + GST % )) )
            //Net Price = Original Cost – GST Amount
            var gstPercentage = taxValues.Sum(x => x.Value);
            var gstDedutionPercentage = 100 / (100 + gstPercentage);
            var priceWithoutGst = SELLINGPRICE * gstDedutionPercentage;
            var netGstTax = SELLINGPRICE - priceWithoutGst;
            TAXAMOUNT = Math.Round(netGstTax, 2);
            return Math.Round(priceWithoutGst, 2);
        }
    }
}
