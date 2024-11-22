using KoiPond.Repositories;
using KoiPond.Repositories.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace KoiPond.Services
{
    // IUserService.cs
    public interface IUserService
    {
        Task<List<IdentityRole>> GetAllRoleAsync();
        Task<IdentityResult> RegisterUserAsync(LoginViewModel model, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
        Task<IdentityUser> FindUserByNameAsync(string userName);
        Task<IdentityResult> ChangeUserPasswordAsync(ChangePasswordViewModel model);
        Task<IdentityResult> ForgotPasswordAsync(ForgotPasswordViewModel model);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel model);
    }

    // UserService.cs
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IUserRepository userRepository, RoleManager<IdentityRole> roleManager)
        {
            _userRepository = userRepository;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(LoginViewModel model, string roleName)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userRepository.CreateUserAsync(user, model.Password);

            if (result.Succeeded)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new IdentityRole { Name = roleName };
                    await _roleManager.CreateAsync(role);
                }
                await _userRepository.AddPasswordAsync(user, model.Password);
                await _userRepository.AddToRoleAsync(user, roleName);
            }

            return result;
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _userRepository.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
        }

        public async Task LogoutAsync()
        {
            await _userRepository.SignOutAsync();
        }

        public async Task<IdentityUser> FindUserByNameAsync(string userName)
        {
            return await _userRepository.FindByNameAsync(userName);
        }

        public async Task<IdentityResult> ChangeUserPasswordAsync(ChangePasswordViewModel model)
        {
            var user = await _userRepository.FindByNameAsync(model.Email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            var removeResult = await _userRepository.RemovePasswordAsync(user);
            if (removeResult.Succeeded)
            {
                return await _userRepository.AddPasswordAsync(user, model.Password);
            }
            return removeResult;
        }

        public async Task<IdentityResult> ForgotPasswordAsync(ForgotPasswordViewModel model)
        {
            var user = await _userRepository.FindByNameAsync(model.Email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }
            // You can implement additional logic here if needed, like generating a reset token.
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            var user = await _userRepository.FindByNameAsync(model.Email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            var removePasswordResult = await _userRepository.RemovePasswordAsync(user);
            if (removePasswordResult.Succeeded)
            {
                return await _userRepository.AddPasswordAsync(user, model.Password);
            }
            return removePasswordResult;
        }

        public async Task<List<IdentityRole>> GetAllRoleAsync()
        {
            return await _userRepository.GetAllRoleAsync();
        }
    }

}
