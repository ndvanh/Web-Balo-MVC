using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebbanBALO.Areas.Admin.Models.Framework;
using System.IO;
namespace WebbanBALO.Areas.Admin.Controllers
{
    public class ThemanhController : Controller
    {
        private WebBaloEntities db = new WebBaloEntities();

        // GET: Admin/Themanh
        public ActionResult Index()
        {
            return View(db.Themanhs.ToList());
        }

        // GET: Admin/Themanh/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Themanh themanh = db.Themanhs.Find(id);
            if (themanh == null)
            {
                return HttpNotFound();
            }
            return View(themanh);
        }

        // GET: Admin/Themanh/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Themanh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Themanh themanh , HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/FilesUpload/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                db.Themanhs.Add(new Themanh
                {
                    Maanh = themanh.Maanh,
                    Upanh = "~/Areas/Admin/FilesUpload/" + file.FileName
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(themanh);
        }

        // GET: Admin/Themanh/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Themanh themanh = db.Themanhs.Find(id);
            if (themanh == null)
            {
                return HttpNotFound();
            }
            return View(themanh);
        }

        // POST: Admin/Themanh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maanh,Upanh")] Themanh themanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(themanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(themanh);
        }

        // GET: Admin/Themanh/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Themanh themanh = db.Themanhs.Find(id);
            if (themanh == null)
            {
                return HttpNotFound();
            }
            return View(themanh);
        }

        // POST: Admin/Themanh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Themanh themanh = db.Themanhs.Find(id);
            db.Themanhs.Remove(themanh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
