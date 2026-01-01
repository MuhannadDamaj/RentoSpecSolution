using Refit;
using RentospectMobileApp.Converters;
using RentospectShared.API;
using RentospectShared.DTOs;

namespace RentospectMobileApp.Services
{
    public class InspectionService
    {
        private readonly IInspectionApi _api;

        public InspectionService(string baseUrl)
        {
            _api = RestService.For<IInspectionApi>(baseUrl);
        }
        public async Task<UploadResponseDto> UploadInspectionAsync(InspectionUploadDto inspection)
        {
            var accessToken = await SecureStorage.GetAsync("jwt_token");

            var response = await _api.UploadInspectionAsync(inspection, $"Bearer {accessToken}");
            if (!response.IsSuccessStatusCode)
            {
                if(response.Content != null)
                    response.Content.Success = false;
                throw new Exception($"Error uploading inspection: {response.StatusCode}");
            }
            response.Content.Success = true;
            return response.Content;
        }

        public async Task UploadAllImagesAsync(Guid inspectionId, List<InspectionImageUploadDto> uploadImages, string? jwtToken)
        {
            var form = new MultipartFormDataContent();

            foreach (var img in uploadImages.OrderBy(i => i.OrderIndex))
            {

                var original = File.ReadAllBytes(img.LocalFilePath);
                var compressed = CompressionHelper.Compress(original);

                var content = new ByteArrayContent(compressed);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                content.Headers.Add("Content-Encoding", "gzip"); // <---- Important flag

                form.Add(content, "files", img.FileName);
            }
            await _api.UploadBulkImagesAsync(inspectionId, form, $"Bearer {jwtToken}");
        }
    }
}
