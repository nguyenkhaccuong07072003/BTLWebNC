using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    public class PhieuNhapController : Controller
    {
        // GET: Admin/PhieuNhap
        QLQCFEntities db = new QLQCFEntities();
        public ActionResult Index()
        {
            List<PHIEUNHAP> pn = db.PHIEUNHAP.ToList();
            return View(pn);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var nccList = db.NCC.ToList();
            var nguoiDungList = db.NguoiDung.Where(u => u.VaiTro == 0).ToList();

            ViewBag.NCC = new SelectList(nccList, "Id", "TenNCC");
            ViewBag.NguoiDung = new SelectList(nguoiDungList, "Id", "HoTen");

            // Create an empty PHIEUNHAP object to pass to the view
            var pn = new PHIEUNHAP();
            return View(pn);
        }

        [HttpPost]
        public ActionResult Create(PHIEUNHAP pn)
        {
            if (ModelState.IsValid)
            {
                pn.NCC = db.NCC.Find(pn.IdNCC);
                pn.NguoiDung = db.NguoiDung.Find(pn.IdNV);

                db.PHIEUNHAP.Add(pn);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            var nguoiDungList = db.NguoiDung.Where(u => u.VaiTro == 0).ToList();
            ViewBag.NCC = new SelectList(db.NCC.ToList(), "Id", "TenNCC", pn.IdNCC);
            ViewBag.NguoiDung = new SelectList(db.NguoiDung.ToList(), "Id", "HoTen", pn.IdNV);

            return View(pn);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var obj = db.PHIEUNHAP.Find(id);
            var nguoiDungList = db.NguoiDung.Where(u => u.VaiTro == 0).ToList();
            ViewBag.NCC = new SelectList(db.NCC.ToList(), "Id", "TenNCC");
            ViewBag.NguoiDung = new SelectList(nguoiDungList, "Id", "HoTen");
            return View(obj);
        }

        [HttpPost]
        public ActionResult Update(PHIEUNHAP obj)
        {
            try
            {
                var pn = db.PHIEUNHAP.Find(obj.Id);
                pn.IdNCC = obj.IdNCC;
                pn.IdNV = obj.IdNV;
                pn.NgayNhap = obj.NgayNhap;
                pn.TongTien = obj.TongTien;
                db.SaveChanges();
            }
            catch { }
            var nguoiDungList = db.NguoiDung.Where(u => u.VaiTro == 0).ToList();
            ViewBag.NCC = new SelectList(db.NCC.ToList(), "Id", "TenNCC");
            ViewBag.NguoiDung = new SelectList(nguoiDungList, "Id", "HoTen");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var obj = db.PHIEUNHAP.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(NCC obj)
        {
            var pn = db.PHIEUNHAP.Find(obj.Id);
            if (pn != null)
            {
                db.PHIEUNHAP.Remove(pn);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}