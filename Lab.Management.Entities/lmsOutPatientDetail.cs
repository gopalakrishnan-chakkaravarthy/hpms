//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab.Management.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class lmsOutPatientDetail
    {
        public int OPDID { get; set; }
        public Nullable<int> OPMASTERID { get; set; }
        public string FINDINGS { get; set; }
        public string PATIENTDESCRIPTION { get; set; }
        public string ADDITIONALCOMMENTS { get; set; }
        public System.DateTime CREATEDDATE { get; set; }
        public string PRESCRIOPTION { get; set; }
    
        public virtual lmsOutPatientMaster lmsOutPatientMaster { get; set; }
    }
}
