//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebbanBALO.Areas.Admin.Models.Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            this.CTdonhangs = new HashSet<CTdonhang>();
        }
    
        public int Masp { get; set; }
        public string Tensp { get; set; }
        public Nullable<int> Madm { get; set; }
        public string Anh { get; set; }
        public Nullable<decimal> Gia { get; set; }
        public string Mota { get; set; }
        public Nullable<int> Soluong { get; set; }
        public Nullable<bool> Trangthai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTdonhang> CTdonhangs { get; set; }
        public virtual Danhmuc Danhmuc { get; set; }
    }
}
