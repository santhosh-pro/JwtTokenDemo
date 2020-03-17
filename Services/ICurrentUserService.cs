using System;

namespace JwtTokenDemo.Services
{
    public interface ICurrentUserService
    {
        int Id { get; set; }
        int UserId { get; }
        string UserType { get; set; }
        bool IsAuthenticated { get; set; }
    }
}
