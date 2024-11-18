using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiPond.Repositories.Models;
using KoiPond.Services.Services;
using KoiPond.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace KoiPond.Controllers
{
    [Authorize]
    public class DanhGiaPhanHoisController : Controller
    {
        private readonly IDanhGiaPhanHoiService _service;
        private readonly IKhachHangService _khachHangService;
        private readonly IYeuCauDichVuService _yeuCauDichVuService;
        private readonly IYeuCauThiCongService _yeuCauThiCongService;

        public DanhGiaPhanHoisController(IDanhGiaPhanHoiService service, IKhachHangService khachHangService, IYeuCauDichVuService yeuCauDichVuService, IYeuCauThiCongService yeuCauThiCongService)
        {
            _khachHangService = khachHangService;
            _service = service;
            _yeuCauDichVuService = yeuCauDichVuService;
            _yeuCauThiCongService = yeuCauThiCongService;
        }

        // GET: DanhGiaPhanHois
        public async Task<IActionResult> Index()
        {
            var danhGiaPhanHois = await _service.GetAllAsync();
            return View(danhGiaPhanHois);
        }

        // GET: DanhGiaPhanHois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var danhGiaPhanHoi = await _service.GetByIdAsync(id.Value);
            if (danhGiaPhanHoi == null)
            {
                return NotFound();
            }

            return View(danhGiaPhanHoi);
        }

        // GET: DanhGiaPhanHois/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["MaKhachHang"] = new SelectList(await _khachHangService.GetAllKhachHangsAsync(), "MaKhachHang", "TenKhachHang");
            ViewData["MaYeuCauDichVu"] = new SelectList(await _yeuCauDichVuService.GetAllAsync(), "MaYeuCau", "MaYeuCau");
            ViewData["MaYeuCauThiCong"] = new SelectList(await _yeuCauThiCongService.GetAllAsync(), "MaYeuCau", "MaYeuCau");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhanHoi,MaKhachHang,MaYeuCauDichVu,MaYeuCauThiCong,DanhGia,BinhLuan,NgayTao")] DanhGiaPhanHoi danhGiaPhanHoi)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(danhGiaPhanHoi);
            }
            ViewData["MaKhachHang"] = new SelectList(await _khachHangService.GetAllKhachHangsAsync(), "MaKhachHang", "TenKhachHang");
            ViewData["MaYeuCauDichVu"] = new SelectList(await _yeuCauDichVuService.GetAllAsync(), "MaYeuCau", "MaYeuCau");
            ViewData["MaYeuCauThiCong"] = new SelectList(await _yeuCauThiCongService.GetAllAsync(), "MaYeuCau", "MaYeuCau");
            return View(danhGiaPhanHoi);
        }

        // GET: DanhGiaPhanHois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var danhGiaPhanHoi = await _service.GetByIdAsync(id.Value);
            if (danhGiaPhanHoi == null)
            {
                return NotFound();
            }

            ViewData["MaKhachHang"] = new SelectList(await _khachHangService.GetAllKhachHangsAsync(), "MaKhachHang", "TenKhachHang");
            ViewData["MaYeuCauDichVu"] = new SelectList(await _yeuCauDichVuService.GetAllAsync(), "MaYeuCau", "MaYeuCau");
            ViewData["MaYeuCauThiCong"] = new SelectList(await _yeuCauThiCongService.GetAllAsync(), "MaYeuCau", "MaYeuCau");
            return View(danhGiaPhanHoi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPhanHoi,MaKhachHang,MaYeuCauDichVu,MaYeuCauThiCong,DanhGia,BinhLuan,NgayTao")] DanhGiaPhanHoi danhGiaPhanHoi)
        {
            if (id != danhGiaPhanHoi.MaPhanHoi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(danhGiaPhanHoi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.ExistsAsync(danhGiaPhanHoi.MaPhanHoi))
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

            ViewData["MaKhachHang"] = new SelectList(await _khachHangService.GetAllKhachHangsAsync(), "MaKhachHang", "TenKhachHang");
            ViewData["MaYeuCauDichVu"] = new SelectList(await _yeuCauDichVuService.GetAllAsync(), "MaYeuCau", "MaYeuCau");
            ViewData["MaYeuCauThiCong"] = new SelectList(await _yeuCauThiCongService.GetAllAsync(), "MaYeuCau", "MaYeuCau");
            return View(danhGiaPhanHoi);
        }

        // GET: DanhGiaPhanHois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var danhGiaPhanHoi = await _service.GetByIdAsync(id.Value);
            if (danhGiaPhanHoi == null)
            {
                return NotFound();
            }

            return View(danhGiaPhanHoi);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
