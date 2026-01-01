using Refit;
using RentospectShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.API
{
    public interface IInspectionApi
    {
        [Post("/api/inspections/upload")]
        Task<ApiResponse<UploadResponseDto>> UploadInspectionAsync([Body] InspectionUploadDto dto,
                                                                   [Header("Authorization")] string authorization);

        // Bulk images upload
        [Multipart]
        [Post("/api/inspections/{inspectionId}/images/bulk")]
        Task<HttpResponseMessage> UploadBulkImagesAsync(
                                                        Guid inspectionId,
                                                        [AliasAs("files")] MultipartFormDataContent files,
                                                        [Header("Authorization")] string auth);
    }
}
