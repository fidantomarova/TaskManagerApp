using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.DTOs;
using TaskManagerApp.Services;

namespace TaskManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        #region Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            if (registerRequestDto == null)
            {
                return BadRequest("Invalid registration request.");
            }
            var response = await _authService.RegisterAsync(registerRequestDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            if (loginRequestDto == null)
            {
                return BadRequest("Invalid login request.");
            }
            var response = await _authService.LoginAsync(loginRequestDto);
            if (!response.IsSuccess)
            {
                return Unauthorized(response);
            }
            return Ok(response);
        }
        #endregion
    }
}
