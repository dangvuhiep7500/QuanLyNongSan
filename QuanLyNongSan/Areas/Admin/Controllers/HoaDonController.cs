using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNongSan.Models;
namespace QuanLyNongSan.Areas.Admin.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: Admin/HoaDon
        NongSanVN db = new NongSanVN();
        public ActionResult Index()
        {
            
            var hd = db.Orders.Include(n => n.Custormer);
            return View(hd.ToList());
        }
        public ActionResult Delete(string id)
        {
            var model = db.Orders.SingleOrDefault(p => p.orderID.Equals(id));
            try
            {
                if (model != null)
                {
                    db.Orders.Remove(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "HoaDon", new { error = "Xoá sản phẩm thành công." });
                }
                else
                {
                    return RedirectToAction("Index", "HoaDon", new { error = "Sản phẩm không tồn tại." });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "HoaDon", new { error = "Không thể xoá sản phẩm." });
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Close()
        {
            return RedirectToAction("Index", "HoaDon");
        }
    }
}