using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    public class PhieuXuatController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/PhieuXuat
        public ActionResult Index()
        {
            List<PHIEUXUAT> px = db.PHIEUXUAT.ToList();
            return View(px);
        }
    }
}