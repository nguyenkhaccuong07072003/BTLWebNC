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
        // GET: Admin/CTDH
        public ActionResult Index()
        {
            return View();
        }
    }
}