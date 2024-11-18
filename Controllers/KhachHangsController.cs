using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiPond.Services;
using KoiPond.Repositories.Models;
using Microsoft.AspNetCore.Authorization;

namespace KoiPond.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class KhachHangsController : Controller
    {
        private readonly IKhachHangService _khachHangService;

        public KhachHangsController(IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
        }

        
        // GET: KhachHangs
        public async Task<IActionResult> Index()
        {
            var khachHangs = await _khachHangService.GetAllKhachHangsAsync();
            return View(khachHangs);
        }

        // GET: KhachHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var khachHang = await _khachHangService.GetKhachHangByIdAsync(id.Value);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // GET: KhachHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhachHang,TenKhachHang,DiaChi,SoDienThoai,Email,NgayTao,DiemTrungThanh,ImagePath")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                await _khachHangService.CreateKhachHangAsync(khachHang);
                return RedirectToAction(nameof(Index));
            }
            return View(khachHang);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var khachHang = await _khachHangService.GetKhachHangByIdAsync(id.Value);
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KhachHang khachHang)
        {
            if (id != khachHang.MaKhachHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _khachHangService.UpdateKhachHangAsync(khachHang);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _khachHangService.KhachHangExistsAsync(khachHang.MaKhachHang))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(khachHang);
        }

        // GET: KhachHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var khachHang = await _khachHangService.GetKhachHangByIdAsync(id.Value);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // POST: KhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _khachHangService.DeleteKhachHangAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
