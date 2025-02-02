﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test3.Models;

namespace test3.Controllers
{
    public class QLKController : Controller
    {
        // GET: QLK
        QLSVEntities db = new QLSVEntities();
        public ActionResult DanhSachKhoa()
        {
            List<Khoa> danhSachKhoa = db.Khoas.ToList();
            return View(danhSachKhoa);
        }
        [HttpGet]
        public ActionResult ThemMoiKhoa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoiKhoa(Khoa khoa)
        {
            QLSVEntities db = new QLSVEntities();
            db.Khoas.Add(khoa);
            db.SaveChanges();
            return RedirectToAction("DanhSachKhoa");
        }
        public ActionResult Xoa(string maKhoa)
        {
            QLSVEntities db = new QLSVEntities();
            var khoa = db.Khoas.Find(maKhoa);
            db.Khoas.Remove(khoa);
            db.SaveChanges();
            return RedirectToAction("DanhSachKhoa");
        }
        [HttpGet]
        public ActionResult Suathongtin(string maKhoa)
        {
            QLSVEntities db = new QLSVEntities();
            var khoa = db.Khoas.Find(maKhoa);
            return View(khoa);
        }
        [HttpPost]
        public ActionResult Suathongtin(Khoa khoa)
        {
            db.Entry(khoa).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DanhSachKhoa");
        }
    }
}