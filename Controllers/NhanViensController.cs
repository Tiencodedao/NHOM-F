using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiPond.Services;
using KoiPond.Repositories.Models;
using Microsoft.AspNetCore.Authorization;

namespace KoiPond.Controllers
{
    [Authorize(Roles = "Admin, Manager")]

    public class NhanViensController : Controller
    {
        private readonly INhanVienService _nhanVienService;

        public NhanViensController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }

        // GET: NhanViens
        public async Task<IActionResult> Index()
        {
            var nhanViens = await _nhanVienService.GetAllNhanViensAsync();
            return View(nhanViens);
        }

        // GET: NhanViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var nhanVien = await _nhanVienService.GetNhanVienByIdAsync(id.Value);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhanViens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhanVien,TenNhanVien,ChucVu,SoDienThoai,Email,NgayTao,ImagePath")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                await _nhanVienService.CreateNhanVienAsync(nhanVien);
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var nhanVien = await _nhanVienService.GetNhanVienByIdAsync(id.Value);
            if (nhanVien == null)
            {
                return NotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNhanVien,TenNhanVien,ChucVu,SoDienThoai,Email,NgayTao,ImagePath")] NhanVien nhanVien)
        {
            if (id != nhanVien.MaNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _nhanVienService.UpdateNhanVienAsync(nhanVien);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _nhanVienService.NhanVienExistsAsync(nhanVien.MaNhanVien))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var nhanVien = await _nhanVienService.GetNhanVienByIdAsync(id.Value);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _nhanVienService.DeleteNhanVienAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
