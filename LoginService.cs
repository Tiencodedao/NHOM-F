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

        // H�m ??ng nh?p
        public User Login(string username, string password)
        {
            // T�m ng??i d�ng theo t�n ??ng nh?p
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);

            // Ki?m tra ng??i d�ng t?n t?i v� m?t kh?u ?�ng
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                Console.WriteLine("??ng nh?p th�nh c�ng!");
                return user;
            }

            Console.WriteLine("T�n ??ng nh?p ho?c m?t kh?u kh�ng ?�ng.");
            return null;
        }

        // H�m ??ng k�
        public bool Register(string username, string password, string name, string confirmPassword)
        {
            // Ki?m tra m?t kh?u x�c nh?n
            if (password != confirmPassword)
            {
                Console.WriteLine("M?t kh?u v� m?t kh?u x�c nh?n kh�ng kh?p.");
                return false;
            }

            // Ki?m tra ng??i d�ng ?� t?n t?i ch?a
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (existingUser != null)
            {
                Console.WriteLine("T�n ng??i d�ng ?� t?n t?i.");
                return false;
            }

            // M� h�a m?t kh?u tr??c khi l?u
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // T?o ng??i d�ng m?i
            var newUser = new User
            {
                Username = username,
                Password = hashedPassword,
                Name = name,
                CreatedAt = DateTime.Now
            };

            // L?u ng??i d�ng m?i v�o database
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            Console.WriteLine("??ng k� th�nh c�ng!");
            return true;
        }
    }
}
