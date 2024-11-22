using KoiPond.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPond.Repositories.Repositories
{
    // ISanPhamRepository.cs
    public interface ISanPhamRepository
    {
        Task<List<SanPham>> GetAllAsync();
        Task<SanPham> GetByIdAsync(int id);
        Task AddAsync(SanPham sanPham);
        Task UpdateAsync(SanPham sanPham);
        Task DeleteAsync(SanPham sanPham);
        Task<bool> ExistsAsync(int id);
    }

    // SanPhamRepository.cs
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly ApplicationDbContext _context;

        public SanPhamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SanPham>> GetAllAsync()
        {
            return await _context.SanPhams.ToListAsync();
        }

        public async Task<SanPham> GetByIdAsync(int id)
        {
            return await _context.SanPhams.FindAsync(id);
        }

        public async Task AddAsync(SanPham sanPham)
        {
            _context.SanPhams.Add(sanPham);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SanPham sanPham)
        {
            _context.SanPhams.Update(sanPham);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SanPham sanPham)
        {
            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.SanPhams.AnyAsync(e => e.MaSanPham == id);
        }
    }

}
