using KoiPond.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiPond.Repositories
{
    // INhanVienRepository.cs
    public interface INhanVienRepository
    {
        Task<List<NhanVien>> GetAllAsync();
        Task<NhanVien> GetByIdAsync(int id);
        Task AddAsync(NhanVien nhanVien);
        Task UpdateAsync(NhanVien nhanVien);
        Task DeleteAsync(NhanVien nhanVien);
        Task<bool> ExistsAsync(int id);
    }

    // NhanVienRepository.cs
    public class NhanVienRepository : INhanVienRepository
    {
        private readonly ApplicationDbContext _context;

        public NhanVienRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<NhanVien>> GetAllAsync()
        {
            return await _context.NhanViens.ToListAsync();
        }

        public async Task<NhanVien> GetByIdAsync(int id)
        {
            return await _context.NhanViens.FirstOrDefaultAsync(m => m.MaNhanVien == id);
        }

        public async Task AddAsync(NhanVien nhanVien)
        {
            _context.NhanViens.Add(nhanVien);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NhanVien nhanVien)
        {
            _context.NhanViens.Update(nhanVien);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(NhanVien nhanVien)
        {
            _context.NhanViens.Remove(nhanVien);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.NhanViens.AnyAsync(e => e.MaNhanVien == id);
        }
    }

}
