using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        Models.QLQCFEntities db = new Models.QLQCFEntities();
        public ActionResult Index()
        {
            List<Models.SanPham> data = db.SanPham.Take(3).ToList();
            ViewBag.ListProducts = data;
            return View();
        }
    }
}