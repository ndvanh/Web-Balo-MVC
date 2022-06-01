using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebbanBALO.Areas.Admin.Models.Framework;

namespace WebbanBALO.Areas.Admin.Controllers
{
    public class KhuyenmaiController : Controller
    {
        private WebBaloEntities db = new WebBaloEntities();

        // GET: Admin/Khuyenmai
        public ActionResult Index()
        {
            return View(db.Khuyenmais.ToList());
        }

        // GET: Admin/Khuyenmai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khuyenmai khuyenmai = db.Khuyenmais.Find(id);
            if (khuyenmai == null)
            {
                return HttpNotFound();
            }
            return View(khuyenmai);
        }

        // GET: Admin/Khuyenmai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Khuyenmai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Makm,Chitietkm,Anhkm")] Khuyenmai khuyenmai)
        {
            if (ModelState.IsValid)
            {
                db.Khuyenmais.Add(khuyenmai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khuyenmai);
        }

        // GET: Admin/Khuyenmai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khuyenmai khuyenmai = db.Khuyenmais.Find(id);
            if (khuyenmai == null)
            {
                return HttpNotFound();
            }
            return View(khuyenmai);
        }

        // POST: Admin/Khuyenmai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Makm,Chitietkm,Anhkm")] Khuyenmai khuyenmai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khuyenmai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khuyenmai);
        }

        // GET: Admin/Khuyenmai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khuyenmai khuyenmai = db.Khuyenmais.Find(id);
            if (khuyenmai == null)
            {
                return HttpNotFound();
            }
            return View(khuyenmai);
        }

        // POST: Admin/Khuyenmai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Khuyenmai khuyenmai = db.Khuyenmais.Find(id);
            db.Khuyenmais.Remove(khuyenmai);
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
