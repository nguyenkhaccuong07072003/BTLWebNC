using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DCCofee.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DCCofee.Controllers
{

    public class DatHangController : Session_userController
    {
        private QLQCFEntities db = new QLQCFEntities();

        public ActionResult DanhSachDonHang()
        {
            int id_khachhang = Get_User();
            var donhang = db.DONHANG.Where(m => m.IdNV == id_khachhang).ToList();
            return View(donhang);
        }

        public ActionResult ChiTietDonHang(int id)
        {
            var chitietdonhang = db.CTDH.Where(m => m.IdDH == id).ToList();
            return View(chitietdonhang);
        }

        public ActionResult Xoa_DH(int id)
        {
            var donhang = db.DONHANG.FirstOrDefault(m => m.Id == id);
            if (donhang != null)
            {
                db.DONHANG.Remove(donhang);
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachDonHang");
        }

        public ActionResult DatHang()
        {
            try
            {
                int id_khachhang = Get_User();
                var khachhang = db.NguoiDung.Find(id_khachhang);

                // Tạo mới đơn hàng
                DONHANG newDonHang = new DONHANG
                {
                    NgayDat = DateTime.Today,
                    IdNV = id_khachhang,
                    DiaChi = khachhang?.DiaChi, // Kiểm tra null để tránh lỗi
                    TongTien = 0,
                };

                db.DONHANG.Add(newDonHang);
                db.SaveChanges();

                int id_donhang = newDonHang.Id;

                // Lấy giỏ hàng của khách hàng
                var id_giohang = db.Giohang1.FirstOrDefault(m => m.ID_KhachHang == id_khachhang);

                // Lấy danh sách sản phẩm trong giỏ hàng
                var danhsachgiohang = db.ChiTietGioHang.Where(ctgh => ctgh.ID_Giohang == id_giohang.ID_GioHang).ToList();

                // Thêm chi tiết đơn hàng từ giỏ hàng
                foreach (var item in danhsachgiohang)
                {
                    CTDH ctdhCreate = new CTDH
                    {
                        IdDH = id_donhang,
                        IdSP = item.ID_SanPham,
                        SoLuong = item.SoLuong,
                        GiaTien = item.DonGia
                    };
                    db.CTDH.Add(ctdhCreate);
                }

                // Lưu thay đổi và xóa giỏ hàng
                db.SaveChanges();
                if (danhsachgiohang.Any())
                {
                    db.ChiTietGioHang.RemoveRange(danhsachgiohang);
                    db.SaveChanges();
                }

                // Cập nhật tổng tiền cho đơn hàng
                var tongtien = db.CTDH.Where(m => m.IdDH == id_donhang).Sum(m => m.GiaTien * m.SoLuong);
                var donhang = db.DONHANG.Find(id_donhang);

                if (donhang != null)
                {
                    donhang.TongTien = tongtien;
                    db.SaveChanges();
                }

                return RedirectToAction("DanhSachDonHang");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và log thông tin lỗi
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception:");
                    Console.WriteLine(ex.InnerException.Message);
                }

                // Chuyển hướng đến trang form_DatHang trong trường hợp lỗi
                return RedirectToAction("form_DatHang", "GioHangTest");
            }
        }
    }

}