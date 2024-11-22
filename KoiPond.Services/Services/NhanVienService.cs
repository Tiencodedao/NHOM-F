using KoiPond.Repositories;
using KoiPond.Repositories.Models;

namespace KoiPond.Services
{
    // INhanVienService.cs
    public interface INhanVienService
    {
        Task<List<NhanVien>> GetAllNhanViensAsync();
        Task<NhanVien> GetNhanVienByIdAsync(int id);
        Task CreateNhanVienAsync(NhanVien nhanVien);
        Task UpdateNhanVienAsync(NhanVien nhanVien);
        Task DeleteNhanVienAsync(int id);
        Task<bool> NhanVienExistsAsync(int id);
    }

    // NhanVienService.cs
    public class NhanVienService : INhanVienService
    {
        private readonly INhanVienRepository _nhanVienRepository;

        public NhanVienService(INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<List<NhanVien>> GetAllNhanViensAsync()
        {
            return await _nhanVienRepository.GetAllAsync();
        }

        public async Task<NhanVien> GetNhanVienByIdAsync(int id)
        {
            return await _nhanVienRepository.GetByIdAsync(id);
        }

        public async Task CreateNhanVienAsync(NhanVien nhanVien)
        {
            await _nhanVienRepository.AddAsync(nhanVien);
        }

        public async Task UpdateNhanVienAsync(NhanVien nhanVien)
        {
            await _nhanVienRepository.UpdateAsync(nhanVien);
        }

        public async Task DeleteNhanVienAsync(int id)
        {
            var nhanVien = await _nhanVienRepository.GetByIdAsync(id);
            if (nhanVien != null)
            {
                await _nhanVienRepository.DeleteAsync(nhanVien);
            }
        }

        public async Task<bool> NhanVienExistsAsync(int id)
        {
            return await _nhanVienRepository.ExistsAsync(id);
        }
    }

}
