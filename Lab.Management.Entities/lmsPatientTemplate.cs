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
    
    public partial class lmsPatientTemplate
    {
        public int PTEMPLATEID { get; set; }
        public Nullable<int> PATIENTID { get; set; }
        public Nullable<int> TEMPLATEID { get; set; }
        public string TEMPLATEDETAILS { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
    
        public virtual lmsPatientRegistration lmsPatientRegistration { get; set; }
        public virtual lmsTemplateMaster lmsTemplateMaster { get; set; }
    }
}