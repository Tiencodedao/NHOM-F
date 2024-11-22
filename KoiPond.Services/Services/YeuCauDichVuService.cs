using KoiPond.Repositories;
using KoiPond.Repositories.Models;
using KoiPond.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPond.Services.Services
{
    // IYeuCauDichVuService.cs
    public interface IYeuCauDichVuService
    {
        Task<List<YeuCauDichVu>> GetAllAsync();

        Task<List<YeuCauDichVu>> GetByUserName(string TenKh);
        Task<YeuCauDichVu> GetByIdAsync(int id);
        Task AddAsync(YeuCauDichVu yeuCauDichVu);
        Task UpdateAsync(YeuCauDichVu yeuCauDichVu);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }

    // YeuCauDichVuService.cs
    public class YeuCauDichVuService : IYeuCauDichVuService
    {
        private readonly IYeuCauDichVuRepository _repository;

        public YeuCauDichVuService(IYeuCauDichVuRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<YeuCauDichVu>> GetByUserName(string TenKh)
        {
            return await _repository.GetByUserName(TenKh);
        }
        public async Task<List<YeuCauDichVu>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<YeuCauDichVu> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(YeuCauDichVu yeuCauDichVu)
        {
            // Additional business logic if necessary
            yeuCauDichVu.TrangThaiDichVu = "Chờ xử lý";
            yeuCauDichVu.NgayTao = DateTime.Now;

            await _repository.AddAsync(yeuCauDichVu);
        }

        public async Task UpdateAsync(YeuCauDichVu yeuCauDichVu)
        {
            yeuCauDichVu.NgayCapNhat = DateTime.Now;
            await _repository.UpdateAsync(yeuCauDichVu);
        }

        public async Task DeleteAsync(int id)
        {
            var yeuCauDichVu = await _repository.GetByIdAsync(id);
            if (yeuCauDichVu != null)
            {
                await _repository.DeleteAsync(yeuCauDichVu);
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }
    }

}
