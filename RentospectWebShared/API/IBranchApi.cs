using Refit;
using RentospectShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.API
{
    [Headers("Authorization: Bearer ")]
    public interface IBranchApi
    {

        [Post("/api/branches")]
        Task<CustomApiResponce> SaveBranchAsync(BranchDto branchDto);
        [Get("/api/branches")]
        Task<BranchDto[]> GetBranchesAsync();
        [Get("/api/branches/{companyId}")]
        Task<BranchDto[]> GetBranchesByCompanyIDAsync(int companyId);
    }
}
