﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab.Management.Entities
{
    public partial class lmsDischargeSummary
    {
        public int SelectedPatient { get; set; }
        public IEnumerable<SelectListItem> PatientDdl { get; set; }
    }
}