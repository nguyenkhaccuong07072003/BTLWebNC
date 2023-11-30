using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DCCofee.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        QLQCFEntities db = new Models.QLQCFEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(NguoiDung obj, string ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    NguoiDung check = db.NguoiDung.FirstOrDefault(m => m.TaiKhoan == obj.TaiKhoan && m.MatKhau == obj.MatKhau);
                    if(check != null)
                    {
                            FormsAuthentication.SetAuthCookie(check.TaiKhoan, false);
                            if (ReturnUrl == null || ReturnUrl == "")
                            {
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                return Redirect(ReturnUrl);
                            }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                    }
                }
                catch
                {

                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login", new { area = "Admin" });
        }
    }
}