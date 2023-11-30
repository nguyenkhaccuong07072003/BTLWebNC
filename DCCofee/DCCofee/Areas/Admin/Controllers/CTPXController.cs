using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    [Authorize]
    public class CTPXController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/CTPX
        public ActionResult Index(int IdPhieuXuat)
        {
            ViewBag.IdPX = IdPhieuXuat;
            List<CTPX> ctpx = db.CTPX.ToList();
            return View(ctpx);
        }
        [HttpGet]
        public ActionResult Create(int IdPX)
        {
            var hangList = db.HangHoa.ToList();
            ViewBag.HangHoa = new SelectList(hangList, "Id", "TenH");

            ViewBag.IdPX = IdPX;
            var ctpx = new CTPX()
            {
                IdPX = IdPX
            };
            return View(ctpx);
        }

        [HttpPost]
        public ActionResult Create(CTPX ctpx)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var phieuXuat = db.PHIEUXUAT.Find(ctpx.IdPX);
                    var hangHoa = db.HangHoa.Find(ctpx.IdH);

                    if (phieuXuat != null && hangHoa != null)
                    {
                        ctpx.PHIEUXUAT = phieuXuat;
                        ctpx.HangHoa = hangHoa;
                        db.CTPX.Add(ctpx);
                        db.SaveChanges();

                        return RedirectToAction("Index", "CTPX", new { area = "Admin", IdPhieuXuat = ctpx.IdPX });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid PHIEUXUAT or HANGHOA");
                    }
                }

                var hangList = db.HangHoa.ToList();
                ViewBag.HangHoa = new SelectList(hangList, "Id", "TenH");
                ViewBag.IdPX = ctpx.IdPX;

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while saving the record.");

            }
            return View(ctpx);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var obj = db.CTPX.Find(id);
            ViewBag.HangHoa = new SelectList(db.HangHoa.ToList(), "Id", "TenH");
            return View(obj);
        }

        [HttpPost]
        public ActionResult Update(CTPX obj)
        {
            var ctpx = db.CTPX.Find(obj.Id);
            ctpx.IdH = obj.IdH;
            ctpx.SoLuong = obj.SoLuong;

            db.SaveChanges();
            ViewBag.HangHoa = new SelectList(db.HangHoa.ToList(), "Id", "TenH");

            return RedirectToAction("Index", "CTPX", new { area = "Admin", IdPhieuXuat = ctpx.IdPX });
        }
    }
}