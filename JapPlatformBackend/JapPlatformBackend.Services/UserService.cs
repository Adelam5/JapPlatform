using AutoMapper;
using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.User;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Interfaces;
using JapPlatformBackend.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JapPlatformBackend.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(UserManager<User> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<GetCurrentUserDto>> GetCurrentUser()
        {
            var userId = UserHelpers.GetLoggedInUserId(httpContextAccessor);

            var user = await userManager.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(u => u.Id == userId)
                ?? throw new UnauthenticatedException("User not authenticated.");




            var response = new ServiceResponse<GetCurrentUserDto>
            {
                Data = mapper.Map<GetCurrentUserDto>(user)
            };

            return response;
        }

    }
}
