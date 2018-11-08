using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagement.System.Common
{

    public class DrugPrice
    {
        public double SELLINGPRICE { get; set; }

        public string DRUGNAME { get; set; }
    }
    public class TestPrice
    {
        public double SELLINGPRICE { get; set; }
        public string TESTNAME { get; set; }
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


    }
    public class TestBillDetails
    {
        public int TESTID { get; set; }
        public string TESTRESULT { get; set; }
        public double COST { get; set; }


    }
}