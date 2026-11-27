
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SSCafe.UserManagement.Application.DTOs;
using SSCafe.UserManagement.Application.Interfaces;
using SSCafe.UserManagement.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SSCafe.UserManagement.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthService(
            IUserRepository repository,
            IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        // LOGIN ONLY
        public AuthResponseDto Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email.Trim());

            // Compare plain-text password with database password
            if (user == null || user.Password != dto.Password)
            {
                throw new Exception("Invalid email or password");
            }

            return new AuthResponseDto
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                Token = GenerateToken(user)
            };
        }

        // GENERATE JWT TOKEN
        private string GenerateToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var secretKey = jwtSettings["Key"];

            if (string.IsNullOrWhiteSpace(secretKey) ||
                Encoding.UTF8.GetByteCount(secretKey) < 32)
            {
                throw new InvalidOperationException(
                    "JWT Key must contain at least 32 bytes.");
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Id.ToString()),

                new Claim(ClaimTypes.Name, user.Name),

                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
