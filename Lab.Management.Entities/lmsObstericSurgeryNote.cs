
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
    
public partial class lmsObstericSurgeryNote
{

    public int OSNID { get; set; }

    public Nullable<int> OASID { get; set; }

    public string NAMEOFSURGERY { get; set; }

    public Nullable<System.DateTime> SURGERYDATE { get; set; }

    public string DBDR { get; set; }

    public string AB { get; set; }

    public string ANAESDR { get; set; }

    public string INDICATION { get; set; }

    public string TYPEOFANAESTHESIA { get; set; }

    public string SURGERYPROCEDURE { get; set; }

    public Nullable<System.DateTime> DELIVERYTIME { get; set; }

    public Nullable<System.DateTime> DELIVERYDATE { get; set; }

    public string WEIGHT { get; set; }

    public Nullable<int> GENDER { get; set; }

    public string APGAR { get; set; }

    public string BLOODGROUP { get; set; }

    public string TREATMENT { get; set; }

    public string OPERATIONREPORT { get; set; }

    public Nullable<System.DateTime> CREATEDDATE { get; set; }



    public virtual lmsObstericAdmissionSheet lmsObstericAdmissionSheet { get; set; }

}

}
