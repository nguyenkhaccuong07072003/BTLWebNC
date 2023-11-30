using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/User
        public ActionResult Index()
        {
            List<NguoiDung> usersWithRoleOne = db.NguoiDung.Where(u => u.VaiTro == 1).ToList();
            return View(usersWithRoleOne);
        }
    }
}