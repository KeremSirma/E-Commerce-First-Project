//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Commerce3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resimler
    {
        public int Id { get; set; }
        public string ResimYolu { get; set; }
        public Nullable<int> ResimUrun { get; set; }
    
        public virtual Urunler Urunler { get; set; }
    }
}
