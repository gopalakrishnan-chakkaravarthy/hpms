
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
    
public partial class lmsInPatientBilling
{

    public int BILLID { get; set; }

    public Nullable<int> PATIENTID { get; set; }

    public Nullable<int> NOOFDAYSTAY { get; set; }

    public Nullable<double> STAFFFEE { get; set; }

    public Nullable<double> BEDROOMCHARGE { get; set; }

    public Nullable<double> DOCTORSFEEPERDAY { get; set; }

    public Nullable<double> OPERATIONCOST { get; set; }

    public Nullable<double> OPERATIINGDOCTORCOST { get; set; }

    public Nullable<double> OPERATIONTHEATERCOST { get; set; }

    public Nullable<double> ANAESTHESIAFEE { get; set; }

    public Nullable<double> OVERALLTESTFEE { get; set; }

    public Nullable<double> SCANFEE { get; set; }

    public Nullable<System.DateTime> CREATEDATE { get; set; }



    public virtual lmsPatientRegistration lmsPatientRegistration { get; set; }

}

}
