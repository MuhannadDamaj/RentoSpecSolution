using RentospectShared.API;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;

namespace RentospectWebAPI.Services
{
    public class AIService
    {
        private readonly IInspektAI _aiApi;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AIService(IInspektAI aiApi, IHttpContextAccessor httpContextAccessor)
        {
            _aiApi = aiApi;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AIResponse> AnalyzeCarAsync(string token, 
                                                      string session, 
                                                      string caseId, 
                                                      List<string> urls, 
                                                      List<string> originalIds)
        {
            var request = new AIRequest
            {
                session = session,
                case_id = caseId,
                urls = urls.ToArray(),
                original_Id = originalIds.ToArray(),
                callback_url = "https://rentospectwebapi20251111015419-e0fdgudsfxg7egdg.uaenorth-01.azurewebsites.net/api/aipayload/callback"
            };

            var bearer = $"Bearer {token}";
            var skipHeader = "1";
            return await _aiApi.AnalyzeCarAsync(bearer, skipHeader,request);
        }
        public (List<string> urls, List<string> originalIds) BuildAIRequestLists(List<InspectionImage> uploadedImages)
        {
            var urls = new List<string>();
            var originalIds = new List<string>();

            var request = _httpContextAccessor.HttpContext.Request;
            string baseUrl = $"{request.Scheme}://{request.Host}";

            foreach (var image in uploadedImages)
            {
                // Assuming InspectionImage has a property FileName (the unique file name)
                urls.Add($"{baseUrl}/inspectionImages/{image.FileName}");
                originalIds.Add(image.FileName); // or image.OriginalFileName if you store original name
            }

            return (urls, originalIds);
        }
    }
}
