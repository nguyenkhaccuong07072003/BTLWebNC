//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DCCofee.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTDH
    {
        public int Id { get; set; }
        public Nullable<int> IdDH { get; set; }
        public Nullable<int> IdSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string MoTa { get; set; }
        public Nullable<double> GiaTien { get; set; }
    
        public virtual DONHANG DONHANG { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}