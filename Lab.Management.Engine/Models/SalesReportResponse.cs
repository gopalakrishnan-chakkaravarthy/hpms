using System;

namespace Lab.Management.Engine.Models
{
    public class SalesReportResponse
    {
        public int BILLID { get; set; }

        public string BILLNAME { get; set; }

        public string CONTACT { get; set; }

        public string MedicineName { get; set; }

        public Nullable<int> QUANTITY { get; set; }

        public Nullable<double> ITEMCOST { get; set; }

        public double? TAXAMOUNT { get; set; }

        public string GSTName { get; set; }
        public Nullable<System.DateTime> BILLDATE { get; set; }
    }
}
