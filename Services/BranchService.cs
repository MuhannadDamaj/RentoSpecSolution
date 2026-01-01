using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;

namespace RentospectWebAPI.Services
{
    public class BranchService
    {
        private readonly RentospectContext _context;
        public BranchService(RentospectContext rentospectContext)
        {
            _context = rentospectContext;
        }
        public async Task<CustomApiResponce> SaveBranchAsync(BranchDto branchDto)
        {
            if (branchDto.ID == 0)
            {
                var branch = new Branch()
                {
                    Name = branchDto.Name,
                    Address = branchDto.Address,
                    Code = branchDto.Code,
                    CompanyID = branchDto.CompanyID,
                    Email = branchDto.Email,
                    IsActive = branchDto.IsActive,
                    PhoneNumber = branchDto.PhoneNumber,
                    Notes = branchDto.Notes,
                };
                _context.Branches.Add(branch);
            }
            else
            {
                var dbBranch = await _context.Branches
                                  .FirstOrDefaultAsync(brach => brach.ID == branchDto.ID);
                if (dbBranch == null)
                    return CustomApiResponce.Error("Branch does not exist");
                dbBranch.Name = branchDto.Name;
                dbBranch.IsActive = branchDto.IsActive;
                branchDto.PhoneNumber = branchDto.PhoneNumber;
                dbBranch.Notes = branchDto.Notes;
                dbBranch.Email = branchDto.Email;
                dbBranch.Address = branchDto.Address;
                dbBranch.Code = branchDto.Code;
                dbBranch.CompanyID = branchDto.CompanyID;
                _context.Branches.Update(dbBranch);
            }
            await _context.SaveChangesAsync();
            return CustomApiResponce.Success();
        }
        public async Task<BranchDto[]> GetBranchesAsync() => await _context.Branches
                                                                              .Where(cmp => cmp.IsActive)
                                                                              .AsNoTracking()
                                                                              .Select(c => new BranchDto
                                                                              {
                                                                                  ID = c.ID,
                                                                                  Name = c.Name,
                                                                                  Address = c.Address,
                                                                                  Code = c.Code,
                                                                                  CompanyID = c.CompanyID,
                                                                                  Email = c.Email,
                                                                                  Notes = c.Notes,
                                                                                  PhoneNumber = c.PhoneNumber,
                                                                                  IsActive = c.IsActive,
                                                                                  CreatedAt = c.CreatedAt,
                                                                                  CreatedBy = c.CreatedBy,
                                                                                  UpdatedAt = c.UpdatedAt,
                                                                                  UpdatedBy = c.UpdatedBy,
                                                                              }).ToArrayAsync();
        public async Task<BranchDto[]> GetBranchesByCompanyIDAsync(int companyId) => await _context.Branches
                                                                                                   .Where(branch => branch.IsActive
                                                                                                                    &&
                                                                                                                    branch.CompanyID == companyId)
                                                                                                   .AsNoTracking()
                                                                                                    .Select(b => new BranchDto
                                                                                                    {
                                                                                                        ID = b.ID,
                                                                                                        Name = b.Name,
                                                                                                        Address = b.Address,
                                                                                                        Code = b.Code,
                                                                                                        CompanyID = b.CompanyID,
                                                                                                        Email = b.Email,
                                                                                                        Notes = b.Notes,
                                                                                                        PhoneNumber = b.PhoneNumber,
                                                                                                        IsActive = b.IsActive,
                                                                                                    }).ToArrayAsync();
    }
}
