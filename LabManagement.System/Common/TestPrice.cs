using System.Collections.Generic;

namespace LabManagement.System.Common
{
    public class TestPrice: BaseTaxCalculator
    {
        public string TESTNAME { get; set; }
        public TestPrice(List<double?> taxValues):base(taxValues)
        {
        }
    }
}