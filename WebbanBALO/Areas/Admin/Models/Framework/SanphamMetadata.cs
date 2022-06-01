using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebbanBALO.Areas.Admin.Models.Framework
{
    [MetadataType(typeof(SanphamMetadata))]
    public partial class Sanpham { }
    public  class SanphamMetadata
    {
        [Required(ErrorMessage = "Mã sản phẩm là bắt buộc")]
        [Display(Name = "Mã sản phẩm")]
        public int Masp { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        [Display(Name = "Tên sản phẩm")]
        public string Tensp { get; set; }
        [Required(ErrorMessage = "Mã danh mục là bắt buộc")]
        [Display(Name = "Mã danh mục")]
        public Nullable<int> Madm { get; set; }
      
        [Display(Name = "Ảnh sản phẩm")]
        public string Anh { get; set; }
        [Required(ErrorMessage = "Giá sản phẩm là bắt buộc")]
        [Display(Name = "Giá sản phẩm")]
        public Nullable<decimal> Gia { get; set; }
        
        [Display(Name = "Mô tả sản phẩm")]
        [MaxLength(500)]
        public string Mota { get; set; }
        [Display(Name = "Số lượng sản phẩm")]
        public Nullable<int> Soluong { get; set; }
        [Display(Name = "Trạng thái sản phẩm")]
        public Nullable<bool> Trangthai { get; set; }
        
    }
}