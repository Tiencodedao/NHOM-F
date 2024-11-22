using KoiPond.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPond.Repositories.Repositories
{
    // IYeuCauDichVuRepository.cs
    public interface IYeuCauDichVuRepository
    {
        Task<List<YeuCauDichVu>> GetAllAsync();
        Task<List<YeuCauDichVu>> GetByUserName(string TenKH);
        Task<YeuCauDichVu> GetByIdAsync(int id);
        Task AddAsync(YeuCauDichVu yeuCauDichVu);
        Task UpdateAsync(YeuCauDichVu yeuCauDichVu);
        Task DeleteAsync(YeuCauDichVu yeuCauDichVu);
        Task<bool> ExistsAsync(int id);
    }

    // YeuCauDichVuRepository.cs
    public class YeuCauDichVuRepository : IYeuCauDichVuRepository
    {
        private readonly ApplicationDbContext _context;

        public YeuCauDichVuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<YeuCauDichVu>> GetAllAsync()
        {
            return await _context.YeuCauDichVus.Include(p => p.NhanVien).ToListAsync();
        }

        public async Task<YeuCauDichVu> GetByIdAsync(int id)
        {
            return await _context.YeuCauDichVus.FirstOrDefaultAsync(m => m.MaYeuCau == id);
        }

        public async Task<List<YeuCauDichVu>> GetByUserName(string TenKh)
        {
            return await _context.YeuCauDichVus.Where(m => m.Email == TenKh).ToListAsync();
        }

        public async Task AddAsync(YeuCauDichVu yeuCauDichVu)
        {
            _context.YeuCauDichVus.Add(yeuCauDichVu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(YeuCauDichVu yeuCauDichVu)
        {
            _context.YeuCauDichVus.Update(yeuCauDichVu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(YeuCauDichVu yeuCauDichVu)
        {
            _context.YeuCauDichVus.Remove(yeuCauDichVu);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.YeuCauDichVus.AnyAsync(e => e.MaYeuCau == id);
        }
    }

}
