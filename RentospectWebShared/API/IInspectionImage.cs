using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.API
{
    public interface IInspectionImage
    {
        [Multipart]
        [Post("/api/inspections/{inspectionId}/images")]
        Task<ApiResponse<string>> UploadImageAsync(
                                                    Guid inspectionId,
                                                    [AliasAs("file")] StreamPart image,
                                                    [Header("Authorization")] string token
                                                  );
    }
}
