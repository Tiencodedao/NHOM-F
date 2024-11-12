using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiPond.Models;

namespace KoiPond.Controllers
{
    public class YeuCauThiCongsController : Controller
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
        public async Task<IActionResult> Create([Bind("MaYeuCau,LoaiThietKe,ChiTietYeuCau,TrangThaiYeuCau,PhanHoi,NgayTao,NgayCapNhat,DiaChi,FileDinhKem,Sdt,SoLuong,TenKhachHang")] YeuCauThiCong yeuCauThiCong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yeuCauThiCong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("MaYeuCau,LoaiThietKe,ChiTietYeuCau,TrangThaiYeuCau,PhanHoi,NgayTao,NgayCapNhat,DiaChi,FileDinhKem,Sdt,SoLuong,TenKhachHang")] YeuCauThiCong yeuCauThiCong)
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
}
