using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNongSan.Common;
using QuanLyNongSan.Models;

namespace QuanLyNongSan.Controllers
{
    public class HomeController : Controller
    {
        NongSanVN db = new NongSanVN();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        
        public PartialViewResult ThanhToan()
        {
            var nsm = db.NongSans.OrderByDescending(s => s.ID).ToList().Take(6);
            return PartialView(nsm);
        }
        public PartialViewResult LeftMenu()
        {
            var Catalog = db.LoaiNS.OrderBy(s => s.NgayTao).ToList();
            return PartialView(Catalog);
        }

        public PartialViewResult Menu()
        {
            var Catalog = db.LoaiNS.OrderBy(s => s.NgayTao).ToList();
            return PartialView(Catalog);
        }
        public PartialViewResult LienHe()
        {
            var Catalog = db.LoaiNS.OrderBy(s => s.NgayTao).ToList();
            return PartialView(Catalog);
        }
        [HttpPost]
        public ActionResult TimkiemNS(string txtTimKiem)
        {
            List<NongSan> kqtk = db.NongSans.Where(s => s.TenNS.Contains(txtTimKiem)).ToList();

            if (kqtk.Count != 0)
            {
                return PartialView(kqtk);
            }
            else
            {
                ViewBag.thongbao = "Không tìm thấy sản phẩm cần tìm";
                return View();
            }
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }
    }
}