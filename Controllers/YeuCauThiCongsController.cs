using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiPond.Repositories.Models;
using KoiPond.Services.Services;
using KoiPond.Services;
using Microsoft.AspNetCore.Authorization;

namespace KoiPond.Controllers
{
    /*
     *  public class YeuCauThiCongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YeuCauThiCongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YeuCauThiCongs
        public async Task<IActionResult> Index()
        {
            return View(await _context.YeuCauThiCongs.ToListAsync());
        }

        // GET: YeuCauThiCongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeuCauThiCong = await _context.YeuCauThiCongs
                .FirstOrDefaultAsync(m => m.MaYeuCau == id);
            if (yeuCauThiCong == null)
            {
                return NotFound();
            }

            return View(yeuCauThiCong);
        }

        // GET: YeuCauThiCongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YeuCauThiCongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaYeuCau,LoaiThietKe,ChiTietYeuCau,TrangThaiYeuCau,PhanHoi,NgayTao,NgayCapNhat,DiaChi,Email,FileDinhKem,Sdt,SoLuong,TenKhachHang")] YeuCauThiCong yeuCauThiCong
            , IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                yeuCauThiCong.NgayTao = DateTime.Now;
                // Ensure the directory exists
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/file");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                // Generate a unique file name to avoid conflicts
                string tenKhachHang = yeuCauThiCong.TenKhachHang ?? "Unknown";
                string sdt = yeuCauThiCong.Sdt ?? "NoPhone";
                string ngayTao = yeuCauThiCong.NgayTao != null ? yeuCauThiCong.NgayTao.Value.ToString("yyyyMMdd_HHmmss") : "NoDate";

                // Replace invalid file name characters with underscores
                tenKhachHang = string.Concat(tenKhachHang.Split(Path.GetInvalidFileNameChars()));
                sdt = string.Concat(sdt.Split(Path.GetInvalidFileNameChars()));

                var uniqueFileName = $"{tenKhachHang}_{sdt}_{ngayTao}{Path.GetExtension(uploadedFile.FileName)}";

                var fullPath = Path.Combine(filePath, uniqueFileName);

                // Save the file
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(stream);
                }

                // Save the file path in the model's FileDinhKem field
                yeuCauThiCong.FileDinhKem = "/file/" + uniqueFileName; // Adjust the path format if necessary

                KhachHang newKh = new KhachHang
                {
                    TenKhachHang = yeuCauThiCong.TenKhachHang,
                    DiaChi = yeuCauThiCong.DiaChi,
                    SoDienThoai = yeuCauThiCong.Sdt,
                    Email = yeuCauThiCong.Email
                };

                _context.Add(newKh);
                await _context.SaveChangesAsync();

                _context.Add(yeuCauThiCong);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Gửi yêu cầu thi công thành công!";
                //return View(yeuCauThiCong);
            }
            return View(yeuCauThiCong);
        }

        // GET: YeuCauThiCongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeuCauThiCong = await _context.YeuCauThiCongs.FindAsync(id);
            if (yeuCauThiCong == null)
            {
                return NotFound();
            }
            return View(yeuCauThiCong);
        }

        // POST: YeuCauThiCongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaYeuCau,LoaiThietKe,ChiTietYeuCau,TrangThaiYeuCau,PhanHoi,NgayTao,NgayCapNhat,DiaChi,Email,FileDinhKem,Sdt,SoLuong,TenKhachHang")] YeuCauThiCong yeuCauThiCong)
        {
            if (id != yeuCauThiCong.MaYeuCau)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yeuCauThiCong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YeuCauThiCongExists(yeuCauThiCong.MaYeuCau))
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
            return View(yeuCauThiCong);
        }

        // GET: YeuCauThiCongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeuCauThiCong = await _context.YeuCauThiCongs
                .FirstOrDefaultAsync(m => m.MaYeuCau == id);
            if (yeuCauThiCong == null)
            {
                return NotFound();
            }

            return View(yeuCauThiCong);
        }

        // POST: YeuCauThiCongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yeuCauThiCong = await _context.YeuCauThiCongs.FindAsync(id);
            if (yeuCauThiCong != null)
            {
                _context.YeuCauThiCongs.Remove(yeuCauThiCong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YeuCauThiCongExists(int id)
        {
            return _context.YeuCauThiCongs.Any(e => e.MaYeuCau == id);
        }
    }
    */


    public class YeuCauThiCongsController : Controller
    {
        private readonly IYeuCauThiCongService _service;
        private readonly IKhachHangService _khachHangService;

        public YeuCauThiCongsController(IYeuCauThiCongService service, IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
            _service = service;
        }

        // GET: YeuCauThiCongs
        [Authorize]
        public async Task<IActionResult> Index()
        {
            // Get the currently logged-in user's username
            var userName = User.Identity?.Name;

            var yeuCauThiCongs = await _service.GetAllAsync();

            if(!User.IsInRole("Admin") && !User.IsInRole("Manager"))
            {
                yeuCauThiCongs = yeuCauThiCongs.Where(p => p.Email ==  userName).ToList();
            }
            return View(yeuCauThiCongs);
        }

        // GET: YeuCauThiCongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var yeuCauThiCong = await _service.GetByIdAsync(id.Value);
            if (yeuCauThiCong == null)
            {
                return NotFound();
            }

            return View(yeuCauThiCong);
        }

        // GET: YeuCauThiCongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YeuCauThiCongs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaYeuCau,LoaiThietKe,ChiTietYeuCau,TrangThaiYeuCau,PhanHoi,NgayTao,NgayCapNhat,DiaChi,Email,FileDinhKem,Sdt,SoLuong,TenKhachHang")] YeuCauThiCong yeuCauThiCong, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                KhachHang newKh = new KhachHang
                {
                    TenKhachHang = yeuCauThiCong.TenKhachHang,
                    DiaChi = yeuCauThiCong.DiaChi,
                    SoDienThoai = yeuCauThiCong.Sdt,
                    Email = yeuCauThiCong.Email
                };
                await _khachHangService.CreateKhachHangAsync(newKh);
                await _service.AddAsync(yeuCauThiCong, uploadedFile);
                TempData["SuccessMessage"] = "Gửi yêu cầu thi công thành công!";
            }
            return View(yeuCauThiCong);
        }

        // GET: YeuCauThiCongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var yeuCauThiCong = await _service.GetByIdAsync(id.Value);
            if (yeuCauThiCong == null)
            {
                return NotFound();
            }
            return View(yeuCauThiCong);
        }

        // POST: YeuCauThiCongs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaYeuCau,LoaiThietKe,ChiTietYeuCau,TrangThaiYeuCau,PhanHoi,NgayTao,NgayCapNhat,DiaChi,Email,FileDinhKem,Sdt,SoLuong,TenKhachHang")] YeuCauThiCong yeuCauThiCong)
        {
            if (id != yeuCauThiCong.MaYeuCau)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(yeuCauThiCong);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.ExistsAsync(yeuCauThiCong.MaYeuCau))
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
            return View(yeuCauThiCong);
        }

        // GET: YeuCauThiCongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var yeuCauThiCong = await _service.GetByIdAsync(id.Value);
            if (yeuCauThiCong == null)
            {
                return NotFound();
            }

            return View(yeuCauThiCong);
        }

        // POST: YeuCauThiCongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
