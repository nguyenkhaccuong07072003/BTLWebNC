using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Controllers
{
    public class Session_userController : Controller
    {
        // GET: Session_user
        /*public ActionResult Index()
        {
            return View();
        }*/
        protected void Set_User(string Taikhoan)
        {
            Session["TaiKhoan"] = Taikhoan;
        }

        protected string Get_User()
        {
            return Session["TaiKhoan"] as string;
        }
    }
}