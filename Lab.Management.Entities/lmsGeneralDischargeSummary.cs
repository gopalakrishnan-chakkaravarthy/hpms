
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
    
public partial class lmsGeneralDischargeSummary
{

    public int SUMMARYID { get; set; }

    public Nullable<int> PATIENTID { get; set; }

    public Nullable<System.DateTime> DOD { get; set; }

    public string INVESTIGATION { get; set; }

    public string PATIENTADMITTEDWITH { get; set; }

    public string PASTHISTORY { get; set; }

    public string FAMILYHISTORY { get; set; }

    public Nullable<System.DateTime> PATIENTDISCHARGEDON { get; set; }

    public string CONDITIONONDISCHARGE { get; set; }

    public string ADVISE { get; set; }

    public string CONSULTINGDOCTOR { get; set; }

    public System.DateTime CREATEDATE { get; set; }

    public string DIAGNOSIS { get; set; }

    public string TREATMENT { get; set; }



    public virtual lmsPatientRegistration lmsPatientRegistration { get; set; }

}

}
