using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        Models.QLQCFEntities db = new Models.QLQCFEntities();
        public ActionResult Index()
        {
            List<SanPham> sp = db.SanPham.ToList();
            return View();
        }
        public ActionResult AddToCart(int id)
        {
            List<Models.CartMoeldcs> lstCart1 = null;
            if(Session["Cart"]==null)
            {
                lstCart1 = new List<Models.CartMoeldcs>();
            }
            else
            {
                lstCart1 = (List<Models.CartMoeldcs>)Session["Cart"];
            }
            Models.CartMoeldcs obj = lstCart1.FirstOrDefault(m => m.Id == id);
            if (obj == null)
            {
                Models.SanPham crrSp = db.SanPham.First(m => m.Id == id);
                obj = new Models.CartMoeldcs
                {
                    Id = id,
                    ChiTiet = crrSp,
                    Quantity = 1,
                    Amount = (double)(1 * crrSp.DonGia),
                    Note = ""

                };
                lstCart1.Add(obj);
            }
            else
            {
                obj.Quantity = obj.Quantity + 1;
                obj.Amount = (double)(obj.Quantity * obj.ChiTiet.DonGia);
            }
            Session["Cart"] = lstCart1;
            return RedirectToAction("Index");
        }
    }
}