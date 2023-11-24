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
        QLQCFEntities db = new QLQCFEntities();
        public ActionResult Index()
        {
            List<SanPham> sp = db.SanPham.ToList();
            return View(sp);
        }
    }
}