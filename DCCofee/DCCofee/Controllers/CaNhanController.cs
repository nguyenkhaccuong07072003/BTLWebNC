using System.Linq;
using System.Web.Mvc;
using DCCofee.Models;

namespace DCCofee.Controllers
{
    public class CaNhanController : Session_userController
    {
        private QLQCFEntities db = new QLQCFEntities();

        // GET: KhachHang/Sua
        public ActionResult Sua()
        {
            int? khachhang = Get_User();

            if (khachhang != null)
            {
                var thongtinkh = db.NguoiDung.Find(khachhang);
                return View(thongtinkh);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Sua(NguoiDung model)
        {
            var update = db.NguoiDung.Find(model.Id);
            update.HoTen = model.HoTen;
            update.Sdt = model.Sdt;
            update.NgaySinh = model.NgaySinh;
            update.DiaChi = model.DiaChi;
            update.GioiTinh = model.GioiTinh;

            db.SaveChanges();
            return View(model);
        }
    }
}
