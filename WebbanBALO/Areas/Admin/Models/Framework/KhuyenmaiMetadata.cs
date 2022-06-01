using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebbanBALO.Areas.Admin.Models.Framework
{
    [MetadataType(typeof(KhuyenmaiMetadata))]
    public partial class Khuyenmai { }
    public class KhuyenmaiMetadata
    {
        [Required(ErrorMessage = "Mã KM là bắt buộc")]
        [Display(Name = "Mã khuyến mãi")]
        public int Makm { get; set; }
        [Required(ErrorMessage = "Chi tiết KM là bắt buộc")]
        [Display(Name = "Chi tiết khuyến mãi")]
        public string Chitietkm { get; set; }
        
        [Display(Name = "Ảnh khuyến mãi")]
        public string Anhkm { get; set; }
    }
}