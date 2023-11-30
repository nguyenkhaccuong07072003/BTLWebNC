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
        public ActionResult Index( )
        {
            List<Models.SanPham> data = db.SanPham.Take(6).ToList();
           /* ViewBag.Hot = data;
            var objProduct = db.SanPham.Where(m => m.Id == id).FirstOrDefault();*/
            return View();
        }
    }
}