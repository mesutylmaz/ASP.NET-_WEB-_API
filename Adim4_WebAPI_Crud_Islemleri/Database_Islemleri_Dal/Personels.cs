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
    
    public partial class Personels
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personels()
        {
            this.SatisHarekets = new HashSet<SatisHarekets>();
        }
    
        public int PersonelID { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string PersonelGorseli { get; set; }
        public int Departmanid { get; set; }
        public bool PersonelDurumu { get; set; }
        public string Adres { get; set; }
        public string PersonelMaili { get; set; }
        public string PersonelTelefon { get; set; }
        public string EgitimBilgisi { get; set; }
        public string YetenekBilgisi { get; set; }
        public string PersonelSifresi { get; set; }
    
        public virtual Departmen Departmen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatisHarekets> SatisHarekets { get; set; }
    }
}