//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database_Islemleri_Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class FaturaKalems
    {
        public int FaturaKalemID { get; set; }
        public string FaturaKalemAciklama { get; set; }
        public int FaturaKalemMiktar { get; set; }
        public decimal FaturaKalemBirimFiyat { get; set; }
        public decimal FaturaKalemTutar { get; set; }
        public int Faturaid { get; set; }
    
        public virtual Faturas Faturas { get; set; }
    }
}