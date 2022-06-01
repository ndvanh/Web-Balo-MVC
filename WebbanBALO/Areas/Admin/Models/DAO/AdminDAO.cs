using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebbanBALO.Areas.Admin.Models.DAO
{
    public class AdminDAO
    {
        private static Models.Framework.WebBaloEntities db = new Models.Framework.WebBaloEntities();

        public static bool checkLogin(string TKad, string MKad)
        {
            // đếm số tk thỏa mãn đk
            int count = db.Admins.Count(x => x.TKad == TKad &&  x.MKad == MKad);
            // nếu count = 1 đăng nhập thành công return true
            return count == 1;
        }
    }
}