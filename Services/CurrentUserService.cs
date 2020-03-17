using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace JwtTokenDemo.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext == null)
            { }
            else
            {
                this.IsAuthenticated = httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
                if (this.IsAuthenticated)
                {
                    this.UserId = int.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name));
                    this.Id = int.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
                    this.UserType = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
                }
            }

        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public bool IsAuthenticated { get; set; }

    }
}
