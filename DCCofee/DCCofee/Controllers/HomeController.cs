using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Controllers
{
    public class HomeController : Controller
    {
        Models.QLQCFEntities db = new Models.QLQCFEntities();
        // GET: Home
        public ActionResult Index()
        {
            List<Models.SanPham> data = db.SanPham.Take(6).ToList();
            ViewBag.HotProducts = data;
            return View();
        }
    }
}