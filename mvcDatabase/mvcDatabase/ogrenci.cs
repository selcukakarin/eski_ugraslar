//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class ogrenci
    {
        public int ogrenci_ID { get; set; }
        public string ad_soyad { get; set; }
        public int ders_ID { get; set; }
    
        public virtual ders ders { get; set; }
    }
}