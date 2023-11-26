using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    public class CTPNController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/CTPN
        public ActionResult Index()
        {
            List<CTPN> ctpn = db.CTPN.ToList();
            return View(ctpn);
        }
    }
}