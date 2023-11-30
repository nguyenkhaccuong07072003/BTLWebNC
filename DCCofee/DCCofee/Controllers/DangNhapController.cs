using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Controllers
{
    public class DangNhapController : Session_userController
    {
        private QLQCFEntities db = new QLQCFEntities();
        public static string GetMD5(string str)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] fromData = Encoding.UTF8.GetBytes(str);
                byte[] targetData = md5.ComputeHash(fromData);

                StringBuilder result = new StringBuilder();

                for (int i = 0; i < targetData.Length; i++)
                {
                    result.Append(targetData[i].ToString("x2"));
                }

                return result.ToString();
            }
        }
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }

        /* [HttpPost]
         public ActionResult DangNhap(TaiKhoan model, string action)
         {
             if (ModelState.IsValid)
             {
                 if (action == "login")
                 {
                     var f_password = GetMD5(model.MatKhau);
                     var data = db.TaiKhoans.FirstOrDefault(s => s.TaiKhoan1.Equals(model.TaiKhoan1) && s.MatKhau.Equals(f_password));

                     if (data != null)
                     {
                         // Thêm session
                         Set_User(data.TaiKhoan1);

                         return RedirectToAction("TrangChu", "TrangChu");
                     }

                     else
                     {
                         ViewBag.error = "Đăng nhập không thành công";
                         return View("DangNhap");
                     }
                 }
                 else if (action == "register")
                 {
                     var check = db.TaiKhoans.FirstOrDefault(s => s.TaiKhoan1 == model.TaiKhoan1);
                     if (check == null)
                     {
                         // Thêm tài khoản mới
                         model.MatKhau = GetMD5(model.MatKhau);
                         db.TaiKhoans.Add(model);
                         db.SaveChanges();

                         // Thêm session
                         Set_User(model.TaiKhoan1);

                         return RedirectToAction("TrangChu", "TrangChu");
                     }
                     else
                     {
                         ViewBag.error = "Email đã tồn tại";
                         return View("DangNhap");
                     }
                 }
             }
             return View("DangNhap");
         }

         private void Set_User(object taiKhoan1)
         {
             throw new NotImplementedException();
         }
     }

     public class TaiKhoan
     {
         public string MatKhau { get; internal set; }
         public object TaiKhoan1 { get; internal set; }
     }*/
    }
}