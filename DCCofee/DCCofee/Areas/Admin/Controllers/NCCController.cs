using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    public class NCCController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/NCC
        public ActionResult Index()
        {
            List<NCC> ncc = db.NCC.ToList();
            return View(ncc);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NCC ncc)
        {
            if (ModelState.IsValid)
            {
                db.NCC.Add(ncc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ncc);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var obj = db.NCC.Find(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Update(NCC obj)
        {
            var ncc = db.NCC.Find(obj.Id);
            ncc.TenNCC = obj.TenNCC;
            ncc.DiaChi = obj.DiaChi;
            ncc.Sdt = obj.Sdt;
            ncc.Email = obj.Email;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var obj = db.NCC.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(NCC obj)
        {
            var ncc = db.NCC.Find(obj.Id);
            if (ncc != null)
            {
                db.NCC.Remove(ncc);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}