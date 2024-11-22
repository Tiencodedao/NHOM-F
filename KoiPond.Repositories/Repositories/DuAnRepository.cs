using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiPond.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiPond.Repositories.Repositories
{
    public interface IDuAnRepository
    {
        Task<List<DuAn>> GetAllDuAnAsync();
        Task<DuAn> GetDuAnByIdAsync(int id);
        Task AddDuAnAsync(DuAn DuAn);
        Task UpdateDuAnAsync(DuAn DuAn);
        Task DeleteDuAnAsync(DuAn DuAn);
        Task<bool> DuAnExistsAsync(int id);
    }

    public class DuAnRepository : IDuAnRepository
    {
        private readonly ApplicationDbContext _context;

        public DuAnRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddDuAnAsync(DuAn DuAn)
        {
            _context.DuAns.Add(DuAn);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDuAnAsync(DuAn DuAn)
        {
            _context.DuAns.Remove(DuAn);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DuAnExistsAsync(int id)
        {
            return await _context.DuAns.AnyAsync(e => e.Id == id);
        }

        public async Task<List<DuAn>> GetAllDuAnAsync()
        {
            return await _context.DuAns.ToListAsync();
        }

        public async Task<DuAn> GetDuAnByIdAsync(int id)
        {
            return await _context.DuAns.FirstOrDefaultAsync(propa => propa.Id == id);
        }

        public async Task UpdateDuAnAsync(DuAn DuAn)
        {
            _context.DuAns.Update(DuAn);
            await _context.SaveChangesAsync();
        }
    }
}
