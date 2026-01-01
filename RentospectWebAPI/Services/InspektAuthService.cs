using RentospectShared.API;
using RentospectShared.DTOs;

namespace RentospectWebAPI.Services
{
    public class InspektAuthService
    {
        private readonly IInspektAuthApi _authApi;

        public InspektAuthService(IInspektAuthApi authApi)
        {
            _authApi = authApi;
        }

        public async Task<AuthenticateResponse> GetAuthTokenAsync()
        {
            return await _authApi.Authenticate(new AuthenticateRequest
            {
                Key = "aGPeMq2EQpUqmiZ7EsZJzS061X4nNQR-z2M-ojcB44E"
            });
        }
    }
}
