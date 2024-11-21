using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiPond.Repositories.Models;
using KoiPond.Services.Services;
using KoiPond.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace KoiPond.Controllers
{
    /*
     * Old controller
     public class DanhGiaPhanHoisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanhGiaPhanHoisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DanhGiaPhanHois
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DanhGiaPhanHois.Include(d => d.MaKhachHangNavigation).Include(d => d.MaYeuCauDichVuNavigation).Include(d => d.MaYeuCauThiCongNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DanhGiaPhanHois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhGiaPhanHoi = await _context.DanhGiaPhanHois
                .Include(d => d.MaKhachHangNavigation)
                .Include(d => d.MaYeuCauDichVuNavigation)
                .Include(d => d.MaYeuCauThiCongNavigation)
                .FirstOrDefaultAsync(m => m.MaPhanHoi == id);
            if (danhGiaPhanHoi == null)
            {
                return NotFound();
            }

            return View(danhGiaPhanHoi);
        }

        // GET: DanhGiaPhanHois/Create
        public IActionResult Create()
        {
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "TenKhachHang", "TenKhachHang");
            ViewData["MaYeuCauDichVu"] = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
            ViewData["MaYeuCauThiCong"] = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
            return View();
        }

        [HttpGet]
        public JsonResult GetFilteredRequests(string tenkh)
        {
            var filteredYeuCauDichVus = _context.YeuCauDichVus
                .Where(y => y.TenKhachHang == tenkh)
                .Select(y => new { y.MaYeuCau})
                .ToList();

            var filteredYeuCauThiCongs = _context.YeuCauThiCongs
                .Where(y => y.TenKhachHang == tenkh)
                .Select(y => new { y.MaYeuCau })
                .ToList();

            return Json(new { YeuCauDichVus = filteredYeuCauDichVus, YeuCauThiCongs = filteredYeuCauThiCongs });
        }



        // POST: DanhGiaPhanHois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhanHoi,MaKhachHang,MaYeuCauDichVu,MaYeuCauThiCong,DanhGia,BinhLuan,NgayTao")] DanhGiaPhanHoi danhGiaPhanHoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhGiaPhanHoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "TenKhachHang");
            ViewData["MaYeuCauDichVu"] = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
            ViewData["MaYeuCauThiCong"] = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
            return View(danhGiaPhanHoi);
        }

        // GET: DanhGiaPhanHois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhGiaPhanHoi = await _context.DanhGiaPhanHois.FindAsync(id);
            if (danhGiaPhanHoi == null)
            {
                return NotFound();
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", danhGiaPhanHoi.MaKhachHang);
            ViewData["MaYeuCauDichVu"] = new SelectList(_context.YeuCauDichVus, "MaYeuCau", "MaYeuCau", danhGiaPhanHoi.MaYeuCauDichVu);
            ViewData["MaYeuCauThiCong"] = new SelectList(_context.YeuCauThiCongs, "MaYeuCau", "MaYeuCau", danhGiaPhanHoi.MaYeuCauThiCong);
            return View(danhGiaPhanHoi);
        }

        // POST: DanhGiaPhanHois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _context.Update(danhGiaPhanHoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhGiaPhanHoiExists(danhGiaPhanHoi.MaPhanHoi))
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
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", danhGiaPhanHoi.MaKhachHang);
            ViewData["MaYeuCauDichVu"] = new SelectList(_context.YeuCauDichVus, "MaYeuCau", "MaYeuCau", danhGiaPhanHoi.MaYeuCauDichVu);
            ViewData["MaYeuCauThiCong"] = new SelectList(_context.YeuCauThiCongs, "MaYeuCau", "MaYeuCau", danhGiaPhanHoi.MaYeuCauThiCong);
            return View(danhGiaPhanHoi);
        }

        // GET: DanhGiaPhanHois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhGiaPhanHoi = await _context.DanhGiaPhanHois
                .Include(d => d.MaKhachHangNavigation)
                .Include(d => d.MaYeuCauDichVuNavigation)
                .Include(d => d.MaYeuCauThiCongNavigation)
                .FirstOrDefaultAsync(m => m.MaPhanHoi == id);
            if (danhGiaPhanHoi == null)
            {
                return NotFound();
            }

            return View(danhGiaPhanHoi);
        }

        // POST: DanhGiaPhanHois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danhGiaPhanHoi = await _context.DanhGiaPhanHois.FindAsync(id);
            if (danhGiaPhanHoi != null)
            {
                _context.DanhGiaPhanHois.Remove(danhGiaPhanHoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhGiaPhanHoiExists(int id)
        {
            return _context.DanhGiaPhanHois.Any(e => e.MaPhanHoi == id);
        }
    }
    */
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
