using System;

namespace JwtTokenDemo.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(int id, int userId, string userType,string key);
        string GenerateToken(int id, int userId, string userType,string key,int expiredTimeInHours);
    }
}
