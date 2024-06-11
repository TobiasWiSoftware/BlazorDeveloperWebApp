using ASPWebAPI.Services.Interface;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;

namespace ASPWebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                LoginResponseDto response = await _loginService.LoginAsync(loginRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
