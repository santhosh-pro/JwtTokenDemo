using JwtTokenDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JwtTokenDemo.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IConfiguration _config;
        public UsersController(IJwtTokenService jwtTokenService, IConfiguration config)
        {
            _jwtTokenService = jwtTokenService;
            _config = config;
        }

        [AllowAnonymous]
        [HttpGet("LoginAdmin")]
        public ActionResult LoginAdmin()
        {
            var key = _config.GetSection("AppSettings:EncryptionKey").Value;
            // Roles = CUSTOMER,ADMIN
            var token = _jwtTokenService.GenerateToken(1, 1, "ADMIN", key);
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpGet("LoginCustomer")]
        public ActionResult LoginCustomer()
        {
            var key = _config.GetSection("AppSettings:EncryptionKey").Value;
            // Roles = CUSTOMER,ADMIN
            var token = _jwtTokenService.GenerateToken(2, 3, "CUSTOMER", key);
            return Ok(token);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Admin only");
        }
        [Authorize]
        [HttpGet("Customers")]
        public ActionResult GetCustomer()
        {
            return Ok("Authorize User Only");
        }
        [AllowAnonymous]
        [HttpGet("all")]
        public ActionResult GetAll()
        {
            return Ok("Any one can view");
        }
    }
}
