using DCCofee.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DCCofee.Models;
namespace DCCofee.Controllers
{
    public class DanhMucController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();

        // GET: DanhMuc
        public ActionResult Index(string searchInput, int? page)
        {
            int pageSize = 5; // Set the number of items per page
            int pageNumber = (page ?? 1);

            IQueryable<Models.SanPham> data = db.SanPham;

            if (!string.IsNullOrEmpty(searchInput))
            {
                // Nếu có từ khóa tìm kiếm, lọc dữ liệu
                data = data.Where(p => p.TenSP.Contains(searchInput));
            }

            // Sắp xếp dữ liệu theo một trường nào đó, ví dụ: theo Id
            data = data.OrderBy(p => p.Id);

            ViewBag.ListProducts = data.ToPagedList(pageNumber, pageSize);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

    }
}