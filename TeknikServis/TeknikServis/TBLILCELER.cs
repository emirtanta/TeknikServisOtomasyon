//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikServis
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLILCELER
    {
        public int ilceId { get; set; }
        public int SehirId { get; set; }
        public string IlceAdi { get; set; }
        public string SehirAdi { get; set; }
    
        public virtual TBLILLER TBLILLER { get; set; }
    }
}
