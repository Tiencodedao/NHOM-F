using KoiPond.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPond.Repositories.Repositories
{
    // IDanhGiaPhanHoiRepository.cs
    public interface IDanhGiaPhanHoiRepository
    {
        Task<List<DanhGiaPhanHoi>> GetAllAsync();
        Task<DanhGiaPhanHoi> GetByIdAsync(int id);
        Task AddAsync(DanhGiaPhanHoi danhGiaPhanHoi);
        Task UpdateAsync(DanhGiaPhanHoi danhGiaPhanHoi);
        Task DeleteAsync(DanhGiaPhanHoi danhGiaPhanHoi);
        Task<bool> ExistsAsync(int id);
    }

    // DanhGiaPhanHoiRepository.cs
    public class DanhGiaPhanHoiRepository : IDanhGiaPhanHoiRepository
    {
        private readonly ApplicationDbContext _context;

        public DanhGiaPhanHoiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DanhGiaPhanHoi>> GetAllAsync()
        {
            return await _context.DanhGiaPhanHois
                .Include(d => d.MaKhachHangNavigation)
                .Include(d => d.MaYeuCauDichVuNavigation)
                .Include(d => d.MaYeuCauThiCongNavigation)
                .ToListAsync();
        }

        public async Task<DanhGiaPhanHoi> GetByIdAsync(int id)
        {
            return await _context.DanhGiaPhanHois
                .Include(d => d.MaKhachHangNavigation)
                .Include(d => d.MaYeuCauDichVuNavigation)
                .Include(d => d.MaYeuCauThiCongNavigation)
                .FirstOrDefaultAsync(m => m.MaPhanHoi == id);
        }

        public async Task AddAsync(DanhGiaPhanHoi danhGiaPhanHoi)
        {
            _context.DanhGiaPhanHois.Add(danhGiaPhanHoi);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DanhGiaPhanHoi danhGiaPhanHoi)
        {
            _context.DanhGiaPhanHois.Update(danhGiaPhanHoi);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(DanhGiaPhanHoi danhGiaPhanHoi)
        {
            _context.DanhGiaPhanHois.Remove(danhGiaPhanHoi);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.DanhGiaPhanHois.AnyAsync(e => e.MaPhanHoi == id);
        }
    }

}
