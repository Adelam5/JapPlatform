using JapPlatformBackend.Core.Dtos.Auth;
using JapPlatformBackend.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JapPlatformBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;


        public AuthController(IAuthService authService)
        {
            this.authService = authService;

        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequestDto request)
        {
            return Ok(await authService.Login(request.Username, request.Password));
        }

        [Authorize(Roles = "Admin, Student")]
        [HttpGet("logout")]
        public ActionResult Logout()
        {
            return Ok(authService.Logout());
        }

    }
}
