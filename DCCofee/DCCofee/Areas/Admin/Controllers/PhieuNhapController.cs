using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    [Authorize]
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
            var nhanvienList = db.NguoiDung.Where(u => u.VaiTro == 0).ToList();

            ViewBag.NCC = new SelectList(nccList, "Id", "TenNCC");
            ViewBag.NguoiDung = new SelectList(nhanvienList, "Id", "HoTen");

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

                pn.TongTien = (double)CalculateTotalAmountForPhieuNhap(pn.Id);

                db.PHIEUNHAP.Add(pn);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            var nhanvienList = db.NguoiDung.Where(u => u.VaiTro == 0).ToList();
            ViewBag.NCC = new SelectList(db.NCC.ToList(), "Id", "TenNCC", pn.IdNCC);
            ViewBag.NguoiDung = new SelectList(nhanvienList, "Id", "HoTen", pn.IdNV);

            return View(pn);
        }
        private decimal CalculateTotalAmountForPhieuNhap(int phieuNhapId)
        {
            var chiTietPhieuNhapList = db.CTPN.Where(ctpn => ctpn.Id == phieuNhapId).ToList();
            decimal totalAmount = 0;

            foreach (var chiTietPhieuNhap in chiTietPhieuNhapList)
            {
                var unitPrice = chiTietPhieuNhap.HangHoa.DonGia;
                totalAmount = totalAmount + (decimal) chiTietPhieuNhap.SoLuong * (decimal)unitPrice;
            }

            return totalAmount;
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var obj = db.PHIEUNHAP.Find(id);
            var nhanvienList = db.NguoiDung.Where(u => u.VaiTro == 0).ToList();
            ViewBag.NCC = new SelectList(db.NCC.ToList(), "Id", "TenNCC");
            ViewBag.NguoiDung = new SelectList(nhanvienList, "Id", "HoTen");
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

                pn.TongTien = (double)CalculateTotalAmountForPhieuNhap(obj.Id);

                db.SaveChanges();
            }
            catch { }

            var nhanvienList = db.NguoiDung.Where(u => u.VaiTro == 0).ToList();
            ViewBag.NCC = new SelectList(db.NCC.ToList(), "Id", "TenNCC");
            ViewBag.NguoiDung = new SelectList(nhanvienList, "Id", "HoTen");
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
        public ActionResult DeleteConfirm(PHIEUNHAP obj)
        {
            var pn = db.PHIEUNHAP.Find(obj.Id);

            if (pn != null)
            {
                var chiTietPhieuNhapList = db.CTPN.Where(ctpn => ctpn.IdPN == obj.Id).ToList();

                foreach (var chiTietPhieuNhap in chiTietPhieuNhapList)
                {
                    db.CTPN.Remove(chiTietPhieuNhap);
                }

                pn.TongTien = (double)CalculateTotalAmountForPhieuNhap(obj.Id);
                db.SaveChanges();

                db.PHIEUNHAP.Remove(pn);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}