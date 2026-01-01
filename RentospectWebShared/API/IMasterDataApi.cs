using Refit;
using RentospectShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.API
{
    public class IMasterDataApi
    {
        [Get("/api/masterdata/sync")]
        Task<SyncDataDto> GetSyncDataAsync();
    }
}
