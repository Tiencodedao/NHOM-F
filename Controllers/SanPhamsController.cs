using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiPond.Repositories.Models;
using KoiPond.Services.Services;
using Microsoft.AspNetCore.Authorization;

namespace KoiPond.Controllers
{
    [Authorize(Roles = "Admin, Manager")]

    public class SanPhamsController : Controller
    {
        private readonly ISanPhamService _service;

        public SanPhamsController(ISanPhamService service)
        {
            _service = service;
        }

        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            var sanPhams = await _service.GetAllSanPhamsAsync();
            return View(sanPhams);
        }

        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var sanPham = await _service.GetSanPhamByIdAsync(id.Value);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SanPhams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSanPham,TenSanPham,DanhMuc,MoTaSanPham,Gia,SoLuongTrongKho,DuongDanFileMau,NgayTao,NgayCapNhat")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                await _service.AddSanPhamAsync(sanPham);
                return RedirectToAction(nameof(Index));
            }
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var sanPham = await _service.GetSanPhamByIdAsync(id.Value);
            if (sanPham == null)
            {
                return NotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSanPham,TenSanPham,DanhMuc,MoTaSanPham,Gia,SoLuongTrongKho,DuongDanFileMau,NgayTao,NgayCapNhat")] SanPham sanPham)
        {
            if (id != sanPham.MaSanPham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateSanPhamAsync(sanPham);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.SanPhamExistsAsync(sanPham.MaSanPham))
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
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var sanPham = await _service.GetSanPhamByIdAsync(id.Value);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteSanPhamAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
