using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;
using RentospectWebAPI.Data.UserRole;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RentospectWebAPI.Services
{
    public class AuthService
    {
        private RentospectContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthService(RentospectContext context,
                           IPasswordHasher<User> passwordHasher,
                           IConfiguration configuration)
        {
            _context = context;
            this._passwordHasher = passwordHasher;
            this._configuration = configuration;
        }
        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users
                            .AsNoTracking()
                            .FirstOrDefaultAsync(u =>
                                                        (u.Role == nameof(UserRoleEnum.Administrator)
                                                            &&
                                                            u.Email == loginDto.UserName
                                                            &&
                                                            !loginDto.IsFromMobile
                                                            &&
                                                            u.IsActive)
                                                        ||
                                                        (u.Role == nameof(UserRoleEnum.Inspector)
                                                            &&
                                                            u.PhoneNumber == loginDto.UserName
                                                            &&
                                                            loginDto.IsFromMobile
                                                            &&
                                                            u.IsActive));
            if (user == null)
            {
                return new AuthResponseDto(default, "Invalid User Name");
            }
            var passWordResult = _passwordHasher.VerifyHashedPassword(user, 
                                                                      user.PasswordHash, 
                                                                      loginDto.Password);
            if (passWordResult == PasswordVerificationResult.Failed)
                return new AuthResponseDto(default, "Incorrect Password");
            //Generate Jtw Tocken
            var jwt = GenerateJtwToken(user);
            var LoggedInUser = new LoggedInUser(user.ID,user.FullName,nameof(UserRoleEnum.Administrator),user.CompanyID,jwt);
                return new AuthResponseDto(LoggedInUser);
        }
        public string GenerateJtwToken(User user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.ID.ToString()),
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.Role,user.Role),
            };
            string? secretKey = _configuration.GetValue<string>("Jwt:Secret");
            var symmetricKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey == null ? string.Empty : secretKey));
            var signingCred = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                                                audience: _configuration.GetValue<string>("Jwt:Audience"),
                                                claims: claims,
                                                expires: DateTime.Now.AddMinutes(_configuration.GetValue<int>("Jwt:ExpiresInMinutes")),
                                                signingCredentials: signingCred);
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
