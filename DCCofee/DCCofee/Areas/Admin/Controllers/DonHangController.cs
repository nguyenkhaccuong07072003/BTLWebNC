using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/DonHang
        public ActionResult Index()
        {
            List<DONHANG> dh = db.DONHANG.ToList();
            return View(dh);
        }
    }
}