using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/SanPham
        public ActionResult Index()
        {
            List<SanPham> sp = db.SanPham.ToList();
            return View(sp);
        }
    }
}