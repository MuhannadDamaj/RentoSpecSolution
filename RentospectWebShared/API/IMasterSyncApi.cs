using Refit;
using RentospectShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.API
{
    [Headers("Authorization: Bearer ")]
    public interface IMasterSyncApi
    {
        [Get("/api/master/sync")]
        Task<MasterSyncDto> GetMasterSyncDtoAsync([AliasAs("userId")] int userId,
                                                  [AliasAs("companyId")] int companyId);
    }
}
