using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbanBALO.Areas.Admin.Models;

namespace WebbanBALO.Areas.Admin.Controllers
{
    
    public class AdLoginController : Controller
    {
        // GET: Admin/AdLogin
        public ActionResult Index()
        {
            return View();
        }

       //[HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult DangnhapAD(Models.DTO.AdminModel ad)
        {
            // check trang thái validation form
            if (ModelState.IsValid)
            {
                // check đăng nhập
                bool isLogin = Models.DAO.AdminDAO.checkLogin(ad.TKad, ad.MKad);
                    if(isLogin == true)
                {
                    Session["TKad"] = ad.TKad;
                    return RedirectToAction("Home", "AdHome");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }

            }
            return View(ad);
        }
        public ActionResult Logout()
        {
            Session.Remove("TKad");
            return RedirectToAction("DangnhapAD");
        }
    }
}