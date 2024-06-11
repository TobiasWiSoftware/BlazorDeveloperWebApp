using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using SharedLibrary.Dtos;
using SharedLibrary.Entities;

namespace ASPWebAPI.Repositories.Interface
{
    public interface ILoginRepo
    {
        Task<UserEntity?> GetUserByEmailAsync(string email);
    }
}
