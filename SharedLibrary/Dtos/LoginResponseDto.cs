using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class LoginResponseDto
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public LoginResponseDto(string email, string token)
        {
            Email = email;
            Token = token;
        }
      
    }
}
