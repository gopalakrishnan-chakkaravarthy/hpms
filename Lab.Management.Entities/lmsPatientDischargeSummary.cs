
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
    
public partial class lmsPatientDischargeSummary
{

    public int SUMMARYID { get; set; }

    public Nullable<int> PATIENTID { get; set; }

    public string IPNO { get; set; }

    public string DOA { get; set; }

    public string DODEL { get; set; }

    public string DOD { get; set; }

    public string DIAGONOSIS { get; set; }

    public string PHNO { get; set; }

    public string OBSTEITICCODE { get; set; }

    public string MODEOFDELIVERY { get; set; }

    public Nullable<System.DateTime> DDATE { get; set; }

    public string DTIME { get; set; }

    public string SEX { get; set; }

    public string URINES { get; set; }

    public string URINED { get; set; }

    public string BLOODHBPERCENT { get; set; }

    public string GPRH { get; set; }

    public string BT { get; set; }

    public string CT { get; set; }

    public string PLATELET { get; set; }

    public string BLOODUREA { get; set; }

    public string BLOOGSUGAR { get; set; }

    public string SRCREATININE { get; set; }

    public string VDRL { get; set; }

    public string HIV { get; set; }

    public string HBSAG { get; set; }

    public string PATIENTADMITTEDWITH { get; set; }

    public string POSTOP_POSTNATALPERIOD { get; set; }

    public string TREATMENT { get; set; }

    public string CONDITIONOFBABY { get; set; }

    public string DISCHARGEADVICE { get; set; }

    public string COMMENTS { get; set; }

    public Nullable<System.DateTime> CREATEDDATE { get; set; }

    public string Investigation { get; set; }

    public Nullable<double> PWEIGHT { get; set; }

    public string PRESENTHISTORY { get; set; }

    public string OBSTETRICHISTORY { get; set; }

    public string HIGHRISK { get; set; }

    public Nullable<double> PWEIGHT2 { get; set; }

    public string DTIME2 { get; set; }

    public string SEX2 { get; set; }

    public Nullable<System.DateTime> DDATE2 { get; set; }



    public virtual lmsPatientRegistration lmsPatientRegistration { get; set; }

}

}
