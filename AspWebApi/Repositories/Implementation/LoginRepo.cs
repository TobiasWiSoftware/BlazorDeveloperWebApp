using ASPWebAPI.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using SharedLibrary.Dtos;
using SharedLibrary.Entities;

namespace ASPWebAPI.Repositories.Implementation
{
    public class LoginRepo : ILoginRepo
    {
        private readonly UserManager<UserEntity> _userManager;

        public LoginRepo(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }


        public async Task<UserEntity?> GetUserByEmailAsync(string email)
        {
            if (_userManager != null)
            {
                return await _userManager.FindByEmailAsync(email);
            }
            throw new ArgumentNullException("UserManager is null");
        }


    }
}
