using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RentospectWebApp.Auth
{
    public class TokenExpirationHandler : DelegatingHandler
    {
        private readonly NavigationManager _navigationManager;
        private readonly AuthStateProvider _authStateProvider;

        public TokenExpirationHandler(NavigationManager navigationManager,
                                      AuthStateProvider authStateProvider)
        {
            _navigationManager = navigationManager;
            _authStateProvider = authStateProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // 1) If token is already expired BEFORE calling API → logout + redirect
            if (_authStateProvider.IsTokenExpired())
            {
                await _authStateProvider.SetLogoutAsync();
                _navigationManager.NavigateTo("/auth/login", true);

                // Return a "fake" successful response so Refit doesn't throw
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(string.Empty)
                };
            }

            // 2) Call the real API
            var response = await base.SendAsync(request, cancellationToken);

            // 3) If API returns 401 (expired/invalid token) → logout + redirect
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await _authStateProvider.SetLogoutAsync();
                _navigationManager.NavigateTo("/auth/login", true);

                // Normalize the response so Refit doesn't throw ApiException(401)
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StringContent(string.Empty);
            }

            return response;
        }
    }
}
