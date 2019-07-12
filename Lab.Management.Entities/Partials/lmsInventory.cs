using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab.Management.Entities
{
    public partial class lmsInventory
    {
        public int SelectedVendor { get; set; }
        public IEnumerable<SelectListItem> VendorDdl { get; set; }
    }
}
