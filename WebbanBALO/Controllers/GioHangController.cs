using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbanBALO.Areas.Admin.Models.Framework;
using WebbanBALO.Models;
namespace WebbanBALO.Controllers
{
    public class GioHangController : Controller
    {
        WebBaloEntities db = new WebBaloEntities();
        // GET: GioHang
        public List<Giohang> LayGioHang()
        {
            List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
            if (lstGioHang == null)
            {
                
                lstGioHang = new List<Giohang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult Themgiohang(int aMasp, string strURL)
        {
            Sanpham sp = db.Sanphams.SingleOrDefault(x => x.Masp == aMasp);
       
            List<Giohang> lstGioHang = LayGioHang();
           
            Giohang sanpham = lstGioHang.Find(x => x.aMasp == aMasp);
            if (sanpham == null)
            {
                sanpham = new Giohang(aMasp);
              
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.aSoLuong++;
                return Redirect(strURL);
            }
        }
        public ActionResult Capnhatgiohang(int aMaSP, FormCollection f)
        {
            
            Sanpham sp = db.Sanphams.SingleOrDefault(x => x.Masp == aMaSP);
           
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<Giohang> lstGioHang = LayGioHang();

            Giohang sanpham = lstGioHang.SingleOrDefault(x => x.aMasp == aMaSP);

            if (sanpham != null)
            {
                sanpham.aSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }
        public ActionResult Xoagiohang(int aMaSP)
        {
        
            Sanpham sp = db.Sanphams.SingleOrDefault(x => x.Masp == aMaSP);
        
            List<Giohang> lstGioHang = LayGioHang();
            Giohang sanpham = lstGioHang.SingleOrDefault(x => x.aMasp == aMaSP);

            if (sanpham != null)
            {
                lstGioHang.RemoveAll(x => x.aMasp == aMaSP);

            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }

        // tạo gd giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (TongSoLuong() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            List<Giohang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
     
        private int TongSoLuong()
        {
            int aTongSoLuong = 0;
            List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
            if (lstGioHang != null)
            {
                aTongSoLuong = lstGioHang.Sum(n => n.aSoLuong);
            }
            return aTongSoLuong;
        }

        private double TongTien()
        {
            double aTongTien = 0;
            List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
            if (lstGioHang != null)
            {
                aTongTien = lstGioHang.Sum(x => x.ThanhTien);
            }
            return aTongTien;
        }
        
        //Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Giohang> lstGioHang = LayGioHang();
            return View(lstGioHang);

        }
    }
}