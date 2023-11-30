using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    [Authorize]
    public class CTPNController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/CTPN
        public ActionResult Index(int IdPhieuNhap)
        {
            ViewBag.IdPN = IdPhieuNhap;
            List<CTPN> ctpn = db.CTPN.ToList();
            return View(ctpn);
        }

        [HttpGet]
        public ActionResult Create(int IdPN)
        {
            var hangList = db.HangHoa.ToList();
            ViewBag.HangHoa = new SelectList(hangList, "Id", "TenH");

            ViewBag.IdPN = IdPN;
            var ctpn = new CTPN()
            {
                IdPN = IdPN
            };
            return View(ctpn);
        }

        [HttpPost]
        public ActionResult Create(CTPN ctpn)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var phieuNhap = db.PHIEUNHAP.Find(ctpn.IdPN);
                    var hangHoa = db.HangHoa.Find(ctpn.IdH);

                    if (phieuNhap != null && hangHoa != null)
                    {
                        ctpn.PHIEUNHAP = phieuNhap;
                        ctpn.HangHoa = hangHoa;
                        db.CTPN.Add(ctpn);
                        db.SaveChanges();

                        return RedirectToAction("Index", "CTPN", new { area = "Admin", IdPhieuNhap = ctpn.IdPN });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid PHIEUNHAP or HANGHOA");
                    }
                }

                var hangList = db.HangHoa.ToList();
                ViewBag.HangHoa = new SelectList(hangList, "Id", "TenH");
                ViewBag.IdPN = ctpn.IdPN;

             }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while saving the record.");
               
            }
            return View(ctpn);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var obj = db.CTPN.Find(id);
            ViewBag.HangHoa = new SelectList(db.HangHoa.ToList(), "Id", "TenH");
            return View(obj);
        }

        [HttpPost]
        public ActionResult Update(CTPN obj)
        {
            var ctpn = db.CTPN.Find(obj.Id);
            ctpn.IdH = obj.IdH;
            ctpn.SoLuong = obj.SoLuong;

            db.SaveChanges();
            ViewBag.HangHoa = new SelectList(db.HangHoa.ToList(), "Id", "TenH");

            return RedirectToAction("Index", "CTPN", new { area = "Admin", IdPhieuNhap = ctpn.IdPN });
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var obj = db.CTPN.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(CTPN obj)
        {
            var ctpn = db.CTPN.Find(obj.Id);

            if (ctpn != null)
            {
                db.CTPN.Remove(ctpn);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "CTPN", new { area = "Admin", IdPhieuNhap = ctpn.IdPN });
        }
    }
}