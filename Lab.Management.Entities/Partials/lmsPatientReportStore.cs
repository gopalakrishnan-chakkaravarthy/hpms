﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab.Management.Entities
{
    public partial class lmsPatientReportStore
    {
        public int SelectedPatient { get; set; }
        public object PatientList { get; set; }

        public int SelectedTemplate { get; set; }
        public IEnumerable<SelectListItem> TemplateDdl { get; set; }
    }
}
