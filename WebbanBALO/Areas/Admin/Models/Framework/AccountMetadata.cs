using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebbanBALO.Areas.Admin.Models.Framework
{
    [MetadataType(typeof(AccountMetadata))]
    public partial class Account { }
    public class AccountMetadata
    {
        [Required]
        [Display(Name ="Tên KH")]
        public string TenKH { get; set; }
        [Required]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string MK { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}