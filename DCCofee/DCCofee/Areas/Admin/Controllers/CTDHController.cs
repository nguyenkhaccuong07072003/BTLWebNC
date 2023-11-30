using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    [Authorize]
    public class CTDHController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/CTDH
        public ActionResult Index()
        {
            List<CTDH> ctdh = db.CTDH.ToList();
            return View(ctdh);
        }

    }
}