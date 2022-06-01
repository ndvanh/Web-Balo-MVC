using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebbanBALO.Areas.Admin.Models.Framework
{
    [MetadataType(typeof(DanhmucMetadata))]
    public partial class Danhmuc { }
    public class DanhmucMetadata
    {
        [Required(ErrorMessage ="Mã danh mục là bắt buộc")]
        [Display(Name = "Mã danh mục")]
        public int Madm { get; set; }
        [Required(ErrorMessage = "Tên danh mục là bắt buộc")]
        [Display(Name = "Tên danh mục")]
        public string Tendm { get; set; }
       
        [Display(Name = "Tên viết tắt")]
        public string Tenvt { get; set; }
        
        [Display(Name = "Mã cha")]
        public Nullable<int> Macha { get; set; }
        [Required]
        [Display(Name = "Thứ tự sắp xếp")]
        public Nullable<int> Thutusx { get; set; }
        [Required]
        [Display(Name = "Thứ tự hiển thị")]
        public string Thutuht { get; set; }
        [Required]
        [Display(Name = "Trạng thái")]
        public Nullable<bool> Trangthai { get; set; }
    }
}