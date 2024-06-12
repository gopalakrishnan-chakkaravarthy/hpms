using System.Collections.Generic;

namespace Lab.Management.Common
{
    public class TestPrice : BaseTaxCalculator
    {
        public string TESTNAME { get; set; }
        public TestPrice(List<double?> taxValues) : base(taxValues)
        {
        }
    }
}
