using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Controllers
{
    public class ThanhToan1Controller : Controller
    {
        // GET: ThanhToan1
        QLQCFEntities db = new QLQCFEntities();
        public ActionResult Index()
        {
            List<DONHANG> sp = db.DONHANG.ToList();
            return View();
        }
    }
}