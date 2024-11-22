using KoiPond.Repositories;
using KoiPond.Repositories.Models;
using KoiPond.Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPond.Services.Services
{
    // IYeuCauThiCongService.cs
    public interface IYeuCauThiCongService
    {
        Task<List<YeuCauThiCong>> GetAllAsync();
        Task<YeuCauThiCong> GetByIdAsync(int id);
        Task AddAsync(YeuCauThiCong yeuCauThiCong, IFormFile uploadedFile);
        Task UpdateAsync(YeuCauThiCong yeuCauThiCong);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }

    // YeuCauThiCongService.cs
    public class YeuCauThiCongService : IYeuCauThiCongService
    {
        private readonly IYeuCauThiCongRepository _repository;

        public YeuCauThiCongService(IYeuCauThiCongRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<YeuCauThiCong>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<YeuCauThiCong> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(YeuCauThiCong yeuCauThiCong, IFormFile uploadedFile)
        {
            // Additional file handling logic
            if (uploadedFile != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/file");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string uniqueFileName = GenerateUniqueFileName(yeuCauThiCong, uploadedFile);
                var fullPath = Path.Combine(filePath, uniqueFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(stream);
                }

                yeuCauThiCong.FileDinhKem = "/file/" + uniqueFileName;
            }

            yeuCauThiCong.NgayTao = DateTime.Now;
            await _repository.AddAsync(yeuCauThiCong);
        }

        private string GenerateUniqueFileName(YeuCauThiCong yeuCauThiCong, IFormFile uploadedFile)
        {
            string tenKhachHang = yeuCauThiCong.TenKhachHang ?? "Unknown";
            string sdt = yeuCauThiCong.Sdt ?? "NoPhone";
            string ngayTao = yeuCauThiCong.NgayTao != null ? yeuCauThiCong.NgayTao.Value.ToString("yyyyMMdd_HHmmss") : "NoDate";

            tenKhachHang = string.Concat(tenKhachHang.Split(Path.GetInvalidFileNameChars()));
            sdt = string.Concat(sdt.Split(Path.GetInvalidFileNameChars()));

            return $"{tenKhachHang}_{sdt}_{ngayTao}{Path.GetExtension(uploadedFile.FileName)}";
        }

        public async Task UpdateAsync(YeuCauThiCong yeuCauThiCong)
        {
            yeuCauThiCong.NgayCapNhat = DateTime.Now;
            await _repository.UpdateAsync(yeuCauThiCong);
        }

        public async Task DeleteAsync(int id)
        {
            var yeuCauThiCong = await _repository.GetByIdAsync(id);
            if (yeuCauThiCong != null)
            {
                await _repository.DeleteAsync(yeuCauThiCong);
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }
    }

}
