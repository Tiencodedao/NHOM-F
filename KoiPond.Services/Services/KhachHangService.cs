using KoiPond.Repositories;
using KoiPond.Repositories.Models;

namespace KoiPond.Services
{
    // In IKhachHangService.cs
    public interface IKhachHangService
    {
        Task CreateKhachHangAsync(KhachHang khachHang);
        Task<List<KhachHang>> GetAllKhachHangsAsync();
        Task<KhachHang> GetKhachHangByIdAsync(int id);
        Task UpdateKhachHangAsync(KhachHang khachHang);
        Task<bool> KhachHangExistsAsync(int id);
        Task DeleteKhachHangAsync(int id);
    }

    // In KhachHangService.cs
    public class KhachHangService : IKhachHangService
    {
        private readonly IKhachHangRepository _khachHangRepository;

        public KhachHangService(IKhachHangRepository khachHangRepository)
        {
            _khachHangRepository = khachHangRepository;
        }

        public async Task CreateKhachHangAsync(KhachHang khachHang)
        {
            await _khachHangRepository.AddAsync(khachHang);
        }
        public async Task<List<KhachHang>> GetAllKhachHangsAsync()
        {
            return await _khachHangRepository.GetAllAsync();
        }
        public async Task<KhachHang> GetKhachHangByIdAsync(int id)
        {
            return await _khachHangRepository.GetByIdAsync(id);
        }
        public async Task UpdateKhachHangAsync(KhachHang khachHang)
        {
            await _khachHangRepository.UpdateAsync(khachHang);
        }

        public async Task<bool> KhachHangExistsAsync(int id)
        {
            return await _khachHangRepository.ExistsAsync(id);
        }

        public async Task DeleteKhachHangAsync(int id)
        {
            var khachHang = await _khachHangRepository.GetByIdAsync(id);
            if (khachHang != null)
            {
                await _khachHangRepository.DeleteAsync(khachHang);
            }
        }
    }

}
