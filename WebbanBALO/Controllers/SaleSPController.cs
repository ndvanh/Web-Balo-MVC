using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbanBALO.Areas.Admin.Models.Framework;

namespace WebbanBALO.Controllers
{
    [ChildActionOnly]
    public class SaleSPController : Controller
    {
        WebBaloEntities db = new WebBaloEntities();
        // GET: SaleSP
        public ActionResult Salesp()
        {
            List<Sale> lst = db.Sales.Take(3).ToList();
            return PartialView(lst);
        }
    }
}