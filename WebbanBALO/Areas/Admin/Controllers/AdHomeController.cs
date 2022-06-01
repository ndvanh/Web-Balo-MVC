using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebbanBALO.Areas.Admin.Controllers
{
    public class AdHomeController : Controller
    {
        // GET: Admin/AdHome
        public ActionResult Home()
        {
            if (!checkLogin())
            {
                return RedirectToAction("DangnhapAD", "AdLogin");
            }
            return View();
        }
        private bool checkLogin()
        {
            if (Session["TKad"] == null || Session["TKad"].ToString() == "")
            {
                return false;
            }
            return true;

        }
    }
}