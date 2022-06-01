﻿using System;
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
    public class SanphamController : Controller
    {
        private WebBaloEntities db = new WebBaloEntities();

        // GET: Admin/Sanpham
        public ActionResult Index()
        {
            var sanphams = db.Sanphams.Include(s => s.Danhmuc);
            return View(sanphams.ToList());
        }

        // GET: Admin/Sanpham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: Admin/Sanpham/Create
        public ActionResult Create()
        {
            ViewBag.Madm = new SelectList(db.Danhmucs, "Madm", "Tendm");
            return View();
        }

        // POST: Admin/Sanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masp,Tensp,Madm,Anh,Gia,Mota,Soluong,Trangthai")] Sanpham sanpham )
        {
          
            if (ModelState.IsValid)
            {
                
                    db.Sanphams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
                

            }
            ViewBag.Masp = new SelectList(db.Sanphams, "Masp", "Tensp", sanpham.Masp);
            return View(sanpham);
        }

        // GET: Admin/Sanpham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.Madm = new SelectList(db.Danhmucs, "Madm", "Tendm", sanpham.Madm);
            return View(sanpham);
        }

        // POST: Admin/Sanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masp,Tensp,Madm,Anh,Gia,Mota,Soluong,Trangthai")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Madm = new SelectList(db.Danhmucs, "Madm", "Tendm", sanpham.Madm);
            return View(sanpham);
        }

        // GET: Admin/Sanpham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: Admin/Sanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sanpham sanpham = db.Sanphams.Find(id);
            db.Sanphams.Remove(sanpham);
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
