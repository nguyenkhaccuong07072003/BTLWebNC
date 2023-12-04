using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DCCofee.Models;
namespace DCCofee.Controllers
{
    public class Session_userController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        protected void Set_User(int id)
        {
            Session["Id"] = id;
        }
        protected int Get_User()
        {
            int idKhachHang = Convert.ToInt32(Session["id"]);
            return idKhachHang;
        }

       

        public ActionResult Logout()
        {
            Session["Id"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}