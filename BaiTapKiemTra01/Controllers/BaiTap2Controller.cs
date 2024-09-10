using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class BaiTap2Controller : Controller
    {
        public IActionResult BaiTap2()
        {
            var sanpham = new SanPhamViewModel
            {
                TenSp = "coffee chồn",
                GiaBan = " (20 triệu VNĐ) 1 kg"
            };
            return View(sanpham);
        }
    }
}
