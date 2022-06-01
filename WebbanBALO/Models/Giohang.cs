using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebbanBALO.Areas.Admin.Models.Framework;
namespace WebbanBALO.Models
{
    public class Giohang
    {
        WebBaloEntities db = new WebBaloEntities();
        public int aMasp { get; set; }
        public string aTensp { get; set; }
        public string aAnhBia { get; set; }
        public double aDonGia { get; set; }
        public int aSoLuong { get; set; }
        public double ThanhTien
        {
            get { return aSoLuong * aDonGia; }
        }
        
        public Giohang(int Masp)
        {
            aMasp = Masp;
            Sanpham sp = db.Sanphams.Single(n => n.Masp == aMasp);
            aTensp = sp.Tensp;
            aAnhBia = sp.Anh;
            aDonGia = double.Parse(sp.Gia.ToString());
            aSoLuong = 1;
        }

    }
}