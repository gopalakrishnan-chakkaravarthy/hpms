using System.Collections.Generic;

namespace Lab.Management.Common
{
    public class DrugPrice : BaseTaxCalculator
    {

        public string DRUGNAME { get; set; }
        public DrugPrice(List<double?> taxValues) : base(taxValues)
        {

        }
    }
}
