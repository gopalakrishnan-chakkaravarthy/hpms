
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
    
public partial class lmsDrugDetail
{

    public int DRUGDETAILID { get; set; }

    public Nullable<int> DRUGDID { get; set; }

    public string VENDORNAME { get; set; }

    public string VENDORADDRESS { get; set; }

    public string VENDORPHONE { get; set; }

    public string VENDORNOTES { get; set; }

    public Nullable<System.DateTime> ORDERDATE { get; set; }

    public Nullable<System.DateTime> MANUFACTUREDATE { get; set; }

    public Nullable<System.DateTime> EXPIRYDATE { get; set; }

    public Nullable<bool> ISEXPIRED { get; set; }

    public Nullable<double> BUYINGPRICE { get; set; }

    public Nullable<double> SELLINGPRICE { get; set; }

    public Nullable<System.DateTime> CREATEDATE { get; set; }

    public Nullable<int> ORDERCOUNT { get; set; }

    public Nullable<int> AVAILABLEORDER { get; set; }

    public string RackNumber { get; set; }

    public string QrCodeContent { get; set; }

    public string QrCodeBase64 { get; set; }



    public virtual lmsDrug lmsDrug { get; set; }

}

}
