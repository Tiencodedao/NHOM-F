using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiPond.Repositories.Models;
using KoiPond.Services.Services;
using KoiPond.Repositories;
using KoiPond.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace KoiPond.Controllers
{
    public class YeuCauDichVusController : Controller
    {
        private readonly IYeuCauDichVuService _service;
        private readonly IKhachHangService _khachHangService;

        public YeuCauDichVusController(IYeuCauDichVuService service, IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
            _service = service;
        }

        // GET: YeuCauDichVus
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var yeuCauDichVus = await _service.GetAllAsync();

            // Get the currently logged-in user's username
            var userName = User.Identity?.Name;

            // Check if the user is in the Admin role
            bool isAdmin = User.IsInRole("Admin") || User.IsInRole("Manager");

            if (isAdmin)
            {
                // If the user is an Admin, get all entries
                yeuCauDichVus = await _service.GetAllAsync();
            }
            else
            {
                // Otherwise, only get entries for the current user
                yeuCauDichVus = await _service.GetByUserName(userName);
            }

            return View(yeuCauDichVus);
        }

        // GET: YeuCauDichVus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var yeuCauDichVu = await _service.GetByIdAsync(id.Value);
            if (yeuCauDichVu == null)
            {
                return NotFound();
            }

            return View(yeuCauDichVu);
        }

        // GET: YeuCauDichVus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YeuCauDichVus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaYeuCau,LoaiDichVu,NgayYeuCau,TrangThaiDichVu,PhanHoi,MaNhanVien,NgayTao,NgayCapNhat,DiaChi,Email,MoTa,Sdt,SoLuong,TenKhachHang")] YeuCauDichVu yeuCauDichVu)
        {
            if (ModelState.IsValid)
            {
                KhachHang newKh = new KhachHang
                {
                    TenKhachHang = yeuCauDichVu.TenKhachHang,
                    DiaChi = yeuCauDichVu.DiaChi,
                    SoDienThoai = yeuCauDichVu.Sdt,
                    Email = yeuCauDichVu.Email
                };
                await _khachHangService.CreateKhachHangAsync(newKh);
                await _service.AddAsync(yeuCauDichVu);
                TempData["SuccessMessage"] = "Gửi yêu cầu dịch vụ thành công!";
            }
            return View(yeuCauDichVu);
        }

        // GET: YeuCauDichVus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var yeuCauDichVu = await _service.GetByIdAsync(id.Value);
            if (yeuCauDichVu == null)
            {
                return NotFound();
            }

            //ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "TenNhanVien");
            return View(yeuCauDichVu);
        }

        // POST: YeuCauDichVus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaYeuCau,LoaiDichVu,NgayYeuCau,TrangThaiDichVu,PhanHoi,MaNhanVien,NgayTao,NgayCapNhat,DiaChi,Email,MoTa,Sdt,SoLuong,TenKhachHang")] YeuCauDichVu yeuCauDichVu)
        {
            if (id != yeuCauDichVu.MaYeuCau)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(yeuCauDichVu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.ExistsAsync(yeuCauDichVu.MaYeuCau))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            //ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "TenNhanVien");
            return View(yeuCauDichVu);
        }

        // GET: YeuCauDichVus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var yeuCauDichVu = await _service.GetByIdAsync(id.Value);
            if (yeuCauDichVu == null)
            {
                return NotFound();
            }

            return View(yeuCauDichVu);
        }

        // POST: YeuCauDichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
