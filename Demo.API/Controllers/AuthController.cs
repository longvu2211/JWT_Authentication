using Demo.API.Dtos;
using Demo.Infrastructure;
using Demo.Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo.API.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AuthController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
            
            if (user == null) return Unauthorized(new ProblemDetails
            {
                Title = "Invalid email or password"
            });
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            return Ok(new { accessToken, refreshToken });
        }
    }
}
