using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbanBALO.Areas.Admin.Models.Framework;


namespace WebbanBALO.Controllers
{
   
    public class BaloController : Controller
    {
        WebBaloEntities db = new WebBaloEntities();
        // GET: Balo
        public ActionResult BaloLaptop()
        {
            List<Sanpham> lst = db.Sanphams.Where(x => x.Madm == 1 && x.Trangthai == true).ToList();
            return View(lst);
        }
        public ActionResult BaloDuLichNam()
        {
            List<Sanpham> lsta = db.Sanphams.Where(x => x.Madm == 3 && x.Trangthai == true).ToList();
            return View(lsta);
        }
        public ActionResult BaloDuLichNu()
        {
            List<Sanpham> lstb = db.Sanphams.Where(x => x.Madm == 4 && x.Trangthai == true).ToList();
            return View(lstb);
        }
        public ActionResult BaloCaoCap()
        {
            List<Sanpham> lstc = db.Sanphams.Where(x => x.Madm == 5 && x.Trangthai == true).ToList();
            return View(lstc);
        }
        public ActionResult BaloHocSinh()
        {
            List<Sanpham> lstd = db.Sanphams.Where(x => x.Madm == 6 && x.Trangthai == true).ToList();
            return View(lstd);
        }

        public ActionResult Chitietsp(int Masp=0)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n => n.Masp == Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }
    }
}