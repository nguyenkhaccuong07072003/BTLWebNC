using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Controllers
{
    public class ChiTietController : Controller
    {
        // GET: ChiTiet
        /*Models.QLQCFEntities db = new Models.QLQCFEntities();*/
        QLQCFEntities db = new QLQCFEntities();
        public ActionResult Index(int id)
        {
            var product = db.SanPham.Find(id);
            return View(product);
        }
    }
}