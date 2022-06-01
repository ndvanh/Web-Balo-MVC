using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbanBALO.Areas.Admin.Models.Framework;

namespace WebbanBALO.Controllers
{
    public class TTKhuyenmaiController : Controller
    {
        WebBaloEntities db = new WebBaloEntities();
        // GET: TTKhuyenmai
        public ActionResult Khuyenmaitt()
        {
            List<Khuyenmai> tt = db.Khuyenmais.ToList();
            return View(tt);
        }
    }
}