using KoiPond.Repositories.Models;
using KoiPond.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPond.Services.Services
{
    // ISanPhamService.cs
    public interface ISanPhamService
    {
        Task<List<SanPham>> GetAllSanPhamsAsync();
        Task<SanPham> GetSanPhamByIdAsync(int id);
        Task AddSanPhamAsync(SanPham sanPham);
        Task UpdateSanPhamAsync(SanPham sanPham);
        Task DeleteSanPhamAsync(int id);
        Task<bool> SanPhamExistsAsync(int id);
    }

    // SanPhamService.cs
    public class SanPhamService : ISanPhamService
    {
        private readonly ISanPhamRepository _repository;

        public SanPhamService(ISanPhamRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SanPham>> GetAllSanPhamsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SanPham> GetSanPhamByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddSanPhamAsync(SanPham sanPham)
        {
            await _repository.AddAsync(sanPham);
        }

        public async Task UpdateSanPhamAsync(SanPham sanPham)
        {
            await _repository.UpdateAsync(sanPham);
        }

        public async Task DeleteSanPhamAsync(int id)
        {
            var sanPham = await _repository.GetByIdAsync(id);
            if (sanPham != null)
            {
                await _repository.DeleteAsync(sanPham);
            }
        }

        public async Task<bool> SanPhamExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }
    }

}
