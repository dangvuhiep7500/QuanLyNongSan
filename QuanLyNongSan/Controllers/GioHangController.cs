using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNongSan.Models;
namespace QuanLyNongSan.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        NongSanVN db = new NongSanVN();
        // GET: Shopper/GioHang
        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);

        }
        [Authorize]
        public ActionResult ThemVaoGio(string SanPhamID)
        {
            if (Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<CartItem>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }

            List<CartItem> giohang = Session["giohang"] as List<CartItem>;  // Gán qua biến giohang dễ code

            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa
            if (giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID) == null) // ko co sp nay trong gio hang
            {
                Models.NongSan sp = db.NongSans.Find(SanPhamID);  // tim sp theo sanPhamID
                CartItem newItem = new CartItem()
                {
                    SanPhamID = SanPhamID,
                    TenSanPham = sp.TenNS,
                    SoLuong = 1,
                    Hinh = sp.HinhAnhDaiDien,
                    DonGia = (Int32.Parse(sp.Price)).ToString()

                };  // Tạo ra 1 CartItem mới

                giohang.Add(newItem);  // Thêm CartItem vào giỏ 
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                CartItem cardItem = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
                cardItem.SoLuong++;
            }

            // Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); 
            return Redirect("/GioHang/Index");
        }
        //Sửa số lượng
        public ActionResult SuaSoLuong(string SanPhamID, int soluongmoi)
        {
            // tìm carditem muon sua
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemSua = giohang.FirstOrDefault(m => m.SanPhamID.Equals(SanPhamID));
            if (itemSua != null)
            {
                if (soluongmoi < 1 || soluongmoi > 100)
                {

                }
                else
                {
                    @ViewBag.GioError = "";
                    itemSua.SoLuong = soluongmoi;
                }
            }
            return Redirect(Request.UrlReferrer.ToString());
            /*return RedirectToAction("Index");*/

        }
        //Xoá khỏi giỏ
        public ActionResult XoaKhoiGio(string SanPhamID)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(m => m.SanPhamID.Equals(SanPhamID));
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return Redirect("/GioHang/Index");
        }
        public ActionResult DeleteAll()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            giohang.Clear();
            return Redirect("/GioHang/Index");
        }
    }
    }
