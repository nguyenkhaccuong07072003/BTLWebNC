using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    [Authorize]
    public class PhieuXuatController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/PhieuXuat
        public ActionResult Index()
        {
            List<PHIEUXUAT> px = db.PHIEUXUAT.ToList();
            return View(px);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var nhanvienList = db.NguoiDung.Where(u => u.VaiTro == 0).ToList();
            ViewBag.NguoiDung = new SelectList(nhanvienList, "Id", "HoTen");

            var px = new PHIEUXUAT();
            return View(px);
        }

        [HttpPost]
        public ActionResult Create(PHIEUXUAT px)
        {
            if (ModelState.IsValid)
            {
                px.NguoiDung = db.NguoiDung.Find(px.IdNV);

                db.PHIEUXUAT.Add(px);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            var nhanvienList = db.NguoiDung.Where(u => u.VaiTro == 0).ToList();
            ViewBag.NguoiDung = new SelectList(nhanvienList, "Id", "HoTen", px.IdNV);

            return View(px);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var obj = db.PHIEUXUAT.Find(id);
            var nhanvienList = db.NguoiDung.Where(u => u.VaiTro == 0).ToList();
            ViewBag.NguoiDung = new SelectList(nhanvienList, "Id", "HoTen");
            return View(obj);
        }

        [HttpPost]
        public ActionResult Update(PHIEUXUAT obj)
        {
            try
            {
                var pn = db.PHIEUXUAT.Find(obj.Id);
                pn.IdNV = obj.IdNV;
                pn.NgayXuat = obj.NgayXuat;
                db.SaveChanges();
            }
            catch { }
            var nhanvienList = db.NguoiDung.Where(u => u.VaiTro == 0).ToList();
            ViewBag.NguoiDung = new SelectList(nhanvienList, "Id", "HoTen");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var obj = db.PHIEUXUAT.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(PHIEUXUAT obj)
        {
            var px = db.PHIEUXUAT.Find(obj.Id);

            if (px != null)
            {
                var chiTietPhieuXuatList = db.CTPX.Where(ctpx => ctpx.Id == obj.Id).ToList();

                foreach (var ChiTietPhieuXuat in chiTietPhieuXuatList)
                {
                    db.CTPX.Remove(ChiTietPhieuXuat);
                }

                db.PHIEUXUAT.Remove(px);

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}