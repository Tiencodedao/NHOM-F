using KoiPond.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPond.Repositories.Repositories
{
    // IYeuCauThiCongRepository.cs
    public interface IYeuCauThiCongRepository
    {
        Task<List<YeuCauThiCong>> GetAllAsync();
        Task<YeuCauThiCong> GetByIdAsync(int id);
        Task AddAsync(YeuCauThiCong yeuCauThiCong);
        Task UpdateAsync(YeuCauThiCong yeuCauThiCong);
        Task DeleteAsync(YeuCauThiCong yeuCauThiCong);
        Task<bool> ExistsAsync(int id);
    }

    // YeuCauThiCongRepository.cs
    public class YeuCauThiCongRepository : IYeuCauThiCongRepository
    {
        private readonly ApplicationDbContext _context;

        public YeuCauThiCongRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<YeuCauThiCong>> GetAllAsync()
        {
            return await _context.YeuCauThiCongs.ToListAsync();
        }

        public async Task<YeuCauThiCong> GetByIdAsync(int id)
        {
            return await _context.YeuCauThiCongs.FirstOrDefaultAsync(m => m.MaYeuCau == id);
        }

        public async Task AddAsync(YeuCauThiCong yeuCauThiCong)
        {
            _context.YeuCauThiCongs.Add(yeuCauThiCong);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(YeuCauThiCong yeuCauThiCong)
        {
            _context.YeuCauThiCongs.Update(yeuCauThiCong);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(YeuCauThiCong yeuCauThiCong)
        {
            _context.YeuCauThiCongs.Remove(yeuCauThiCong);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.YeuCauThiCongs.AnyAsync(e => e.MaYeuCau == id);
        }
    }

}
