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
    
    public partial class lmsTemplateMaster
    {
        public lmsTemplateMaster()
        {
            this.lmsPatientTemplates = new HashSet<lmsPatientTemplate>();
        }
    
        public int TEMPLATEID { get; set; }
        public string TEMPLATENAME { get; set; }
        public Nullable<int> SIGNATUREID { get; set; }
        public string TEMPLATEDETAILS { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
    
        public virtual ICollection<lmsPatientTemplate> lmsPatientTemplates { get; set; }
        public virtual lmsSignatureMaster lmsSignatureMaster { get; set; }
    }
}