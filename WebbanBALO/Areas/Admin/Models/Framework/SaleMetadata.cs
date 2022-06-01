using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebbanBALO.Areas.Admin.Models.Framework
{
    [MetadataType(typeof(SaleMetadata))]
    public partial class Sale { }
    public class SaleMetadata
    {
        [Required(ErrorMessage = "Mã sale là bắt buộc")]
        [Display(Name = "Mã sale")]
        public int Masale { get; set; }
        [Required(ErrorMessage = "Tên SP sale là bắt buộc")]
        [Display(Name = "Tên SP sale")]
        public string Tenspsale { get; set; }
        [Required(ErrorMessage = "Giá sale là bắt buộc")]
        [Display(Name = "Giá sale")]
        public Nullable<decimal> Giasale { get; set; }
        [Display(Name = "Ảnh sale")]
        public string Anhsp { get; set; }
    }
}