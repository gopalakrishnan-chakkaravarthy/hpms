
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
    
public partial class lmsScan
{

    public lmsScan()
    {

        this.lmsScanReportMasters = new HashSet<lmsScanReportMaster>();

    }


    public int SCANID { get; set; }

    public string SCANNAME { get; set; }



    public virtual ICollection<lmsScanReportMaster> lmsScanReportMasters { get; set; }

}

}
