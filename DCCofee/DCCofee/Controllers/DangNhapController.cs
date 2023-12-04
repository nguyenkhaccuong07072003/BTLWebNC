using DCCofee.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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


        // GET: Login
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(NguoiDung model, string action)
        {
            if (ModelState.IsValid)
            {
                if (action == "login")
                {
                    var f_password = GetMD5(model.MatKhau);
                    var data = db.NguoiDung.FirstOrDefault(s => s.TaiKhoan.Equals(model.TaiKhoan) && s.MatKhau.Equals(f_password));
                   
                    if (data != null)
                    {
                        Set_User(data.Id);
                        if (data.VaiTro == 1)
                        {
                            // Check if VaiTro is 1 and redirect to a specific action in Home controller
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction("DangNhap", "DangNhap");
                        }
                      
                    }

                    else
                    {
                        ViewBag.error = "Đăng nhập không thành công";
                        return View("DangNhap");
                    }
                }
                else if (action == "register")
                {
                    var check = db.NguoiDung.FirstOrDefault(s => s.TaiKhoan == model.TaiKhoan);
                    if (check == null)
                    {
                        // Thêm tài khoản mới
                        model.MatKhau = GetMD5(model.MatKhau);
                        db.NguoiDung.Add(model);
                        db.SaveChanges();

                        Set_User(model.Id);

                        return RedirectToAction("Index", "Home");
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


    }
}

