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
    public class DanhmucController : Controller
    {
        private WebBaloEntities db = new WebBaloEntities();

        // GET: Admin/Danhmuc
        public ActionResult Index()
        {
            var danhmucs = db.Danhmucs.Include(d => d.Danhmuc2);
            return View(danhmucs.ToList());
        }

        // GET: Admin/Danhmuc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danhmuc danhmuc = db.Danhmucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        // GET: Admin/Danhmuc/Create
        public ActionResult Create()
        {
            ViewBag.Macha = new SelectList(db.Danhmucs, "Madm", "Tendm");
            return View();
        }

        // POST: Admin/Danhmuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Madm,Tendm,Tenvt,Macha,Thutusx,Thutuht,Trangthai")] Danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                db.Danhmucs.Add(danhmuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Macha = new SelectList(db.Danhmucs, "Madm", "Tendm", danhmuc.Macha);
            return View(danhmuc);
        }

        // GET: Admin/Danhmuc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danhmuc danhmuc = db.Danhmucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.Macha = new SelectList(db.Danhmucs, "Madm", "Tendm", danhmuc.Macha);
            return View(danhmuc);
        }

        // POST: Admin/Danhmuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Madm,Tendm,Tenvt,Macha,Thutusx,Thutuht,Trangthai")] Danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhmuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Macha = new SelectList(db.Danhmucs, "Madm", "Tendm", danhmuc.Macha);
            return View(danhmuc);
        }

        // GET: Admin/Danhmuc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danhmuc danhmuc = db.Danhmucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        // POST: Admin/Danhmuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Danhmuc danhmuc = db.Danhmucs.Find(id);
            db.Danhmucs.Remove(danhmuc);
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
