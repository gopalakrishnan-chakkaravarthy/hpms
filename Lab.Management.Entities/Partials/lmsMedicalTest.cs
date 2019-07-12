using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab.Management.Entities
{
    public partial class lmsMedicalTest
    {
        public int SelectedGroup { get; set; }
        public IEnumerable<SelectListItem> GroupForDdl { get; set; }
        public int SelectedTestFor { get; set; }
        public IEnumerable<SelectListItem> TestForForDdl { get; set; }
    }
}
