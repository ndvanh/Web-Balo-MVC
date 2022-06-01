using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebbanBALO.Areas.Admin.Models
{
    [MetadataType(typeof(SanphamMasterdata))]
    public partial class SanphamMasterdata
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
}