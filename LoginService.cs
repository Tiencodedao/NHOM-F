using KOI_POND_WEB.Models;
using KOI_POND_WEB.Services.Interfaces;
using System;
using System.Linq;
using BCrypt.Net;

namespace KOI_POND_WEB.Services
{
    public class LoginService : ILoginService
    {
        private readonly KoiPondDbContext _dbContext;

        public LoginService(KoiPondDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Hàm ??ng nh?p
        public User Login(string username, string password)
        {
            // Tìm ng??i dùng theo tên ??ng nh?p
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);

            // Ki?m tra ng??i dùng t?n t?i và m?t kh?u ?úng
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                Console.WriteLine("??ng nh?p thành công!");
                return user;
            }

            Console.WriteLine("Tên ??ng nh?p ho?c m?t kh?u không ?úng.");
            return null;
        }

        // Hàm ??ng ký
        public bool Register(string username, string password, string name, string confirmPassword)
        {
            // Ki?m tra m?t kh?u xác nh?n
            if (password != confirmPassword)
            {
                Console.WriteLine("M?t kh?u và m?t kh?u xác nh?n không kh?p.");
                return false;
            }

            // Ki?m tra ng??i dùng ?ã t?n t?i ch?a
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (existingUser != null)
            {
                Console.WriteLine("Tên ng??i dùng ?ã t?n t?i.");
                return false;
            }

            // Mã hóa m?t kh?u tr??c khi l?u
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // T?o ng??i dùng m?i
            var newUser = new User
            {
                Username = username,
                Password = hashedPassword,
                Name = name,
                CreatedAt = DateTime.Now
            };

            // L?u ng??i dùng m?i vào database
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            Console.WriteLine("??ng ký thành công!");
            return true;
        }
    }
}
