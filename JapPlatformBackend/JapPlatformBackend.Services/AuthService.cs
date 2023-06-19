using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Auth;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JapPlatformBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AuthService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<ServiceResponse<LoginResponseDto>> Login(string username, string password)
        {
            var user = await userManager.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(u => u.UserName.Equals(username.ToLower().Trim()))
                ?? throw new UnauthenticatedException("Invalid Credentials!");

            var result = await signInManager.CheckPasswordSignInAsync(user, password, false);

            if (!result.Succeeded) throw new UnauthenticatedException("Invalid Credentials!");

            string token = await CreateToken(user);

            if (httpContextAccessor.HttpContext != null)
                httpContextAccessor.HttpContext.Response.Cookies.Append("token", token,
                     new CookieOptions
                     {
                         Expires = DateTime.Now.AddDays(1),
                         HttpOnly = true,
                         Secure = true,
                         IsEssential = true,
                         SameSite = SameSiteMode.None
                     });

            var response = new ServiceResponse<LoginResponseDto>
            {
                Data = new LoginResponseDto
                {
                    Id = user.Id,
                    Role = user.UserRoles.First().Role.Name
                }
            };

            return response;
        }

        public ServiceResponse<int> Logout()
        {

            if (httpContextAccessor.HttpContext != null)
                httpContextAccessor.HttpContext.Response.Cookies.Delete("token");

            var response = new ServiceResponse<int>
            {
                Data = 0
            };

            return response;
        }

        private async Task<string> CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            var roles = await userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var secret = configuration.GetSection("AppSettings:JwtSecret").Value;

            if (string.IsNullOrEmpty(secret))
            {
                throw new JapPlatformException("Invalid jwt secret");
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
