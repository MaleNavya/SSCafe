
using Microsoft.AspNetCore.Mvc;
using SSCafe.UserManagement.Application.DTOs;
using SSCafe.UserManagement.Application.Services;

namespace SSCafe.UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            try
            {
                var result = _authService.Login(dto);

                return Ok(new
                {
                    message = "Login successful",
                    data = result
                });
            }
            catch
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password"
                });
            }
        }
    }
}
