namespace Lab.Management.Engine.Models
{
    public class BillPrintModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }

        public int? Quantity { get; set; }

        public double? UnitPrice { get; set; }

    }
}
