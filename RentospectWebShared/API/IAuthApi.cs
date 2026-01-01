using Refit;
using RentospectShared.DTOs;

namespace RentospectShared.API
{
    public interface IAuthApi
    {
        [Post("/api/auth/login")]
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    }
}
