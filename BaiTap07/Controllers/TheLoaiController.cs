﻿using BaiTap07.Data;
using BaiTap07.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BaiTap07.Controllers
{
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.theLoai.ToList();
            ViewBag.TheLoai = theloai;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.theLoai.Add(theloai);
                // Lưu lại
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.theLoai.Find(id);
            return View(theloai);
        }

        [HttpPost]
        public IActionResult Edit(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.theLoai.Update(theloai);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.theLoai.Find(id);
            return View(theloai);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.theLoai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            _db.theLoai.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.theLoai.Find(id);
            return View(theloai);
        }

        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                // sử dụng để tìm kiếm
                var TheLoai = _db.theLoai
                    .Where(tl => tl.Name.Contains(searchString))
                    .ToList();

                ViewBag.TheLoai = TheLoai;
            }
            else
            {
                var theloai = _db.theLoai.ToList();
                ViewBag.theLoai = theloai;
            }
            return View("Index"); //sử dụng lại view index
        }
    }
}