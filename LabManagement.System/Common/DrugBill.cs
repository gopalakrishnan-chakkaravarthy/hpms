using System.Collections.Generic;

namespace LabManagement.System.Common
{

    public class DrugPrice : BaseTaxCalculator
    {

        public string DRUGNAME { get; set; }
        public DrugPrice(List<double?> taxValues) : base(taxValues)
        {

        }
    }
    public class DrugBill
    {
        public string BILLNAME { get; set; }
        public string CONTACT { get; set; }
    }
    public class TestBill
    {
        public string BILLNAME { get; set; }
        public string CONTACT { get; set; }
    }

    public class DrugBillDetails
    {
        public int DRUGID { get; set; }
        public int QUANTITY { get; set; }
        public double COST { get; set; }
        public double TAXAMOUNT { get; set; }

    }
    public class TestBillDetails
    {
        public int TESTID { get; set; }
        public string TESTRESULT { get; set; }
        public double COST { get; set; }
        public double TAXAMOUNT { get; set; }


    }
}