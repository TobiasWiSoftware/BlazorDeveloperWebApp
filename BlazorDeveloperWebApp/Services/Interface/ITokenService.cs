using Microsoft.AspNetCore.Identity.Data;
using SharedLibrary.Dtos;
using SharedLibrary.Entities;

namespace ASPWebAPI.Services.Interface
{
    public interface ITokenService
    {
        public string? GenerateToken(LoginRequest request);
    }
}
