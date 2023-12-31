﻿using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    [Authorize]
    public class SanPhamController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/SanPham
        public ActionResult Index()
        {
            List<SanPham> sp = db.SanPham.ToList();
            return View(sp);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham obj)
        {
            if (ModelState.IsValid)
            {
                var fImage = Request.Files["fImage"];
                if(fImage != null && fImage.ContentLength > 0)
                {
                    //Lưu file vào server
                    string filename = fImage.FileName;
                    string foldername = Server.MapPath("~/Assets/Upload/" + filename);
                    fImage.SaveAs(foldername);
                    obj.AnhSP = "/Assets/Upload/" + filename;
                }
            }
            db.SanPham.Add(obj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var obj = db.SanPham.Find(id);
            ViewBag.ImageFileName = System.IO.Path.GetFileName(obj.AnhSP);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Update(Models.SanPham obj)
        {
            try
            {
                var masp = db.SanPham.Find(obj.Id);
                var fImage = Request.Files["fImage"];
                if (fImage != null && fImage.ContentLength > 0)
                {
                    string fileName = fImage.FileName;
                    string folderName = Server.MapPath("~/Assets/Upload/" + fileName);
                    fImage.SaveAs(folderName);
                    masp.AnhSP = "/Assets/Upload/" + fileName;
                }
                masp.TenSP = obj.TenSP;
                masp.Mota = obj.Mota;
                masp.DonGia = obj.DonGia;
                db.SaveChanges();
            }
            catch { }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var obj = db.SanPham.Find(id);
            ViewBag.ImageFileName = System.IO.Path.GetFileName(obj.AnhSP);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(SanPham obj)
        {
            var sp = db.SanPham.Find(obj.Id);
            if (sp != null)
            {
                db.SanPham.Remove(sp);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}