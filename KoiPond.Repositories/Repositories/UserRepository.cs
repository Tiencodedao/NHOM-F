using KoiPond.Repositories.Models;
using KoiPond.Repositories.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KoiPond.Repositories
{
    // IUserRepository.cs
    public interface IUserRepository
    {
        Task<List<IdentityRole>> GetAllRoleAsync();
        Task<IdentityUser> FindByNameAsync(string userName);
        Task<IdentityResult> CreateUserAsync(IdentityUser user, string password);
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task SignOutAsync();
        Task<IdentityResult> RemovePasswordAsync(IdentityUser user);
        Task<IdentityResult> AddPasswordAsync(IdentityUser user, string password);
        Task<IList<string>> GetRoleNamebyUser(IdentityUser user);
        Task<IdentityResult> AddToRoleAsync(IdentityUser user, string roleName);
    }

    // UserRepository.cs
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IdentityResult> CreateUserAsync(IdentityUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IList<string>> GetRoleNamebyUser(IdentityUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> RemovePasswordAsync(IdentityUser user)
        {
            return await _userManager.RemovePasswordAsync(user);
        }

        public async Task<IdentityResult> AddPasswordAsync(IdentityUser user, string password)
        {
            return await _userManager.AddPasswordAsync(user, password);
        }

        public async Task<IdentityResult> AddToRoleAsync(IdentityUser user, string roleName)
        {
            return await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<List<IdentityRole>> GetAllRoleAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        // Additional methods as required
    }

}
