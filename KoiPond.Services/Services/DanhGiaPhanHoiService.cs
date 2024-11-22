using KoiPond.Repositories.Models;
using KoiPond.Repositories.Repositories;

namespace KoiPond.Services.Services
{
    // IDanhGiaPhanHoiService.cs
    public interface IDanhGiaPhanHoiService
    {
        Task<List<DanhGiaPhanHoi>> GetAllAsync();
        Task<DanhGiaPhanHoi> GetByIdAsync(int id);
        Task AddAsync(DanhGiaPhanHoi danhGiaPhanHoi);
        Task UpdateAsync(DanhGiaPhanHoi danhGiaPhanHoi);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }

    // DanhGiaPhanHoiService.cs
    public class DanhGiaPhanHoiService : IDanhGiaPhanHoiService
    {
        private readonly IDanhGiaPhanHoiRepository _repository;

        public DanhGiaPhanHoiService(IDanhGiaPhanHoiRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DanhGiaPhanHoi>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<DanhGiaPhanHoi> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(DanhGiaPhanHoi danhGiaPhanHoi)
        {
            await _repository.AddAsync(danhGiaPhanHoi);
        }

        public async Task UpdateAsync(DanhGiaPhanHoi danhGiaPhanHoi)
        {
            await _repository.UpdateAsync(danhGiaPhanHoi);
        }

        public async Task DeleteAsync(int id)
        {
            var danhGiaPhanHoi = await _repository.GetByIdAsync(id);
            if (danhGiaPhanHoi != null)
            {
                await _repository.DeleteAsync(danhGiaPhanHoi);
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }
    }

}
