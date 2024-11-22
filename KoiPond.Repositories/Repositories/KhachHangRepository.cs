using KoiPond.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiPond.Repositories
{
    // In IKhachHangRepository.cs
    public interface IKhachHangRepository
    {
        Task AddAsync(KhachHang khachHang);
        Task<List<KhachHang>> GetAllAsync();
        Task<KhachHang> GetByIdAsync(int id);
        Task UpdateAsync(KhachHang khachHang);
        Task<bool> ExistsAsync(int id);
        Task DeleteAsync(KhachHang khachHang);
    }

    // In KhachHangRepository.cs
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly ApplicationDbContext _context;

        public KhachHangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(KhachHang khachHang)
        {
            _context.Add(khachHang);
            await _context.SaveChangesAsync();
        }
        public async Task<List<KhachHang>> GetAllAsync()
        {
            return await _context.KhachHangs.ToListAsync();
        }

        public async Task<KhachHang> GetByIdAsync(int id)
        {
            return await _context.KhachHangs.FirstOrDefaultAsync(m => m.MaKhachHang == id);
        }

        public async Task UpdateAsync(KhachHang khachHang)
        {
            _context.Update(khachHang);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.KhachHangs.AnyAsync(e => e.MaKhachHang == id);
        }

        public async Task DeleteAsync(KhachHang khachHang)
        {
            _context.KhachHangs.Remove(khachHang);
            await _context.SaveChangesAsync();
        }
    }
}
