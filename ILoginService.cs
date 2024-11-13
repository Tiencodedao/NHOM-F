using KOI_POND_WEB.Models;

namespace KOI_POND_WEB.Services.Interfaces
{
    public interface ILoginService
    {
        User Login(string username, string password);
        bool Register(string username, string password, string name, string confirmPassword);
    }
}
