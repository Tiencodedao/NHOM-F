using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiPond.Repositories.Models;
using KoiPond.Repositories.Repositories;
using Microsoft.AspNetCore.Http;

namespace KoiPond.Services.Services
{
    // IDuAnService.cs
    public interface IDuAnService
    {
        Task<List<DuAn>> GetAllDuAnAsync();
        Task<DuAn> GetDuAnByIdAsync(int id);
        Task AddDuAnAsync(DuAn DuAn, IFormFile formFile);
        Task UpdateDuAnAsync(DuAn DuAn);
        Task DeleteDuAnAsync(DuAn DuAn);
        Task<bool> DuAnExistsAsync(int id);
    }

    // DuAnService.cs
    public class DuAnService : IDuAnService
    {
        private readonly IDuAnRepository _repository;

        public DuAnService(IDuAnRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DuAn>> GetAllDuAnAsync()
        {
            return await _repository.GetAllDuAnAsync();
        }

        public async Task<DuAn> GetDuAnByIdAsync(int id)
        {
            return await _repository.GetDuAnByIdAsync(id);
        }

        public async Task AddDuAnAsync(DuAn DuAn, IFormFile uploadedFile)
        {
            // Additional file handling logic
            if (uploadedFile != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string uniqueFileName = GenerateUniqueFileName(DuAn, uploadedFile);
                var fullPath = Path.Combine(filePath, uniqueFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(stream);
                }

                DuAn.HinhAnh = "/img/" + uniqueFileName;
            }

            await _repository.AddDuAnAsync(DuAn);
        }
        private string GenerateUniqueFileName(DuAn duan, IFormFile uploadedFile)
        {
            string tenDuan = duan.TenDuAn ?? "Unknown";

            // Loại bỏ dấu tiếng Việt và các ký tự đặc biệt
            tenDuan = RemoveDiacritics(tenDuan);

            // Loại bỏ các ký tự không hợp lệ cho tên tệp
            tenDuan = string.Concat(tenDuan.Split(Path.GetInvalidFileNameChars()));

            // Tạo tên tệp với phần mở rộng từ tệp tải lên
            return $"{tenDuan}{Path.GetExtension(uploadedFile.FileName)}";
        }

        // Hàm loại bỏ dấu tiếng Việt
        private string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).Replace(" ", "").ToLower();
        }


        public async Task UpdateDuAnAsync(DuAn DuAn)
        {
            await _repository.UpdateDuAnAsync(DuAn);
        }

        public async Task DeleteDuAnAsync(DuAn DuAn)
        {
            await _repository.DeleteDuAnAsync(DuAn);
        }

        public async Task<bool> DuAnExistsAsync(int id)
        {
            return await _repository.DuAnExistsAsync(id);
        }
    }
}
