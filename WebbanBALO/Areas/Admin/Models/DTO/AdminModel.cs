using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebbanBALO.Areas.Admin.Models.DTO
{
    public class AdminModel
    {
        [Required(ErrorMessage ="Tài khoản không được để trống!")]
        public string TKad { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [DataType(DataType.Password)]
        public string MKad { get; set; }
    }
}