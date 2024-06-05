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

        public async Task<SignInResult> LoginAsync(LoginRequest request)
        {
            // Name == Email !
            UserEntity? correctUser = await _userManager.FindByNameAsync(request.Email);
            if (correctUser != null)
            {
                bool loginOk = await _userManager.CheckPasswordAsync(correctUser, request.Password);
                if (loginOk)
                {
                    return SignInResult.Success;
                }
            }
            return SignInResult.Failed;
        }







    }
}
