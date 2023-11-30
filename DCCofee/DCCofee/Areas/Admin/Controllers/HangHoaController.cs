using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    [Authorize]
    public class HangHoaController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/HangHoa
        public ActionResult Index()
        {
            List<HangHoa> hh = db.HangHoa.ToList();
            return View(hh);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HangHoa hh)
        {
            if (ModelState.IsValid)
            {
                db.HangHoa.Add(hh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hh);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var obj = db.HangHoa.Find(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Update(HangHoa obj)
        {
             var hh = db.HangHoa.Find(obj.Id);
             hh.TenH = obj.TenH;
             hh.SoLuong = obj.SoLuong;
             hh.HSD = obj.HSD;
             hh.DonViTinh = obj.DonViTinh;
             hh.DonGia = obj.DonGia;
             db.SaveChanges();
             return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var obj = db.HangHoa.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(NCC obj)
        {
            var hh = db.HangHoa.Find(obj.Id);
            if (hh != null)
            {
                db.HangHoa.Remove(hh);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}