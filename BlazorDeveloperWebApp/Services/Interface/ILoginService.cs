using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using SharedLibrary.Dtos;

namespace ASPWebAPI.Services.Interface
{
    public interface ILoginService
    {
        public Task<LoginResponseDto> LoginAsync(LoginRequest loginRequest);
    }
}
