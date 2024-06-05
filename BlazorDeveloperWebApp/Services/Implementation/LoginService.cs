using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using SharedLibrary.Entities;
using ASPWebAPI.Services.Interface;
using ASPWebAPI.Repositories.Interface;
using SharedLibrary.Dtos;
using System.Data;



namespace ASPWebAPI.Services.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _loginRepo;
        private readonly ITokenService _tokenService;
        
        public LoginService(ILoginRepo loginRepo, ITokenService tokenService)
        {
            _loginRepo = loginRepo;
            _tokenService = tokenService;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequest loginRequest)
        {
            SignInResult result = await _loginRepo.LoginAsync(loginRequest);
            if (result == SignInResult.Success)
            {
                string token = _tokenService.GenerateToken(loginRequest);
                return new LoginResponseDto(loginRequest.Email, token);
            }
            throw new Exception("Login failed");    
        }
    }
}
