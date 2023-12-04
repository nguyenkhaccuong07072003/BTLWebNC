using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DCCofee.Models;
using DCCofee.Controllers;
using System.Data.Entity.Validation;

namespace DCCofee.Controllers
{
    public class GioHangTestController : Session_userController
    {
        QLQCFEntities db = new QLQCFEntities();

        [HttpGet]
        public ActionResult Index()
        {
            int? id_khachhang = Get_User();
           
            if (id_khachhang != null)
            {
                var giohang = db.Giohang1.FirstOrDefault(m => m.ID_KhachHang == id_khachhang);
                if (giohang != null)
                {
                    return View(db.ChiTietGioHang.Where(ctgh => ctgh.ID_Giohang == giohang.ID_GioHang).ToList());
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(int giohang)
        {
            return View(db.ChiTietGioHang.Where(ctgh => ctgh.ID_Giohang == giohang).ToList());
        }

        public ActionResult AddToCart(int? sanpham)
        {
            try
            {

                int? khachhang = Get_User();

                int id_giohang = check_giohang(khachhang);
                var find_sp = db.SanPham.Find(sanpham);
                var check_sp = db.ChiTietGioHang.Where(ctgh => ctgh.ID_Giohang == id_giohang && ctgh.ID_SanPham == sanpham).FirstOrDefault();
                if (check_sp == null)
                {
                    db.ChiTietGioHang.Add(new ChiTietGioHang
                    {
                        ID_Giohang = id_giohang,
                        ID_SanPham = sanpham,
                        SoLuong = 1,
                        DonGia = find_sp.DonGia,
                        HinhAnh = find_sp.AnhSP
                    });
                }
                else
                {
                    check_sp.SoLuong += 1;
                }
                db.SaveChanges();
                return RedirectToAction("Index", new { giohang = id_giohang });
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine("loi" + ex.Message);
            }
            return RedirectToAction("ChiTietSanPham", "ChiTietSanPham", new { id = sanpham });
        }
        public ActionResult up_number(int id_ctgh, int number)
        {
            var chiTietGioHang = db.ChiTietGioHang.Find(id_ctgh);

            if (chiTietGioHang != null)
            {
                // Đảm bảo số lượng không âm
                chiTietGioHang.SoLuong += number;
                if (chiTietGioHang.SoLuong > 0)
                {
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", new { id_giohang = chiTietGioHang.ID_Giohang });
        }

        private int check_giohang(int? khachhang)
        {
            var GioHang = db.Giohang1.FirstOrDefault(g => g.ID_KhachHang == khachhang);
            if (GioHang == null)
            {
                var newCart = new Giohang1 { ID_KhachHang = khachhang };
                db.Giohang1.Add(newCart);
                db.SaveChanges();

                return newCart.ID_GioHang;
            }
            return GioHang.ID_GioHang;
        }
        public ActionResult xoa_sanpham(int? id_ctgh)
        {
            var find_ctgh = db.ChiTietGioHang.Find(id_ctgh);
            if (find_ctgh != null)
            {
                db.ChiTietGioHang.Remove(find_ctgh);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult form_DatHang()
        {
            int? khachhang = Get_User();
           
            if (khachhang != null)
            {
                var thongtinkh = db.NguoiDung.Find(khachhang);
                var giohang = db.Giohang1.FirstOrDefault(m => m.ID_KhachHang == khachhang);
                if (giohang != null)
                {
                    ViewBag.danhsachGH = db.ChiTietGioHang.Where(ctgh => ctgh.ID_Giohang == giohang.ID_GioHang).ToList();
                }
                return View(thongtinkh);
            }
            return View();

        }
        [HttpPost]
        public ActionResult form_DatHang(NguoiDung model)
        {
            var update = db.NguoiDung.Find(model.Id);
            update.HoTen = model.HoTen;
            update.Sdt = model.Sdt;
            update.NgaySinh = model.NgaySinh;
            update.DiaChi = model.DiaChi;
            update.GioiTinh = model.GioiTinh;
         
            db.SaveChanges();

            var giohang = db.Giohang1.FirstOrDefault(m => m.ID_KhachHang == model.Id);
            if (giohang != null)
            {
                ViewBag.danhsachGH = db.ChiTietGioHang.Where(ctgh => ctgh.ID_Giohang == giohang.ID_GioHang).ToList();
            }
            return View(model);
        }
    }
}

