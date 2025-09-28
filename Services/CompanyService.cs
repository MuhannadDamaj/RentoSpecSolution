using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RentospectWebAPI.Services
{
    public class CompanyService
    {
        private readonly RentospectContext _context;
        private readonly IWebHostEnvironment _env;

        public CompanyService(RentospectContext rentospectContext,
                              IWebHostEnvironment env)
        {
            _context = rentospectContext;
            _env = env;
        }
        public async Task<CustomApiResponce> SaveCompanyAsync(CompanyDto companyDto)
        {
            try
            {
                if (companyDto.LogoBytes != null && companyDto.Logo != null)
                {
                    var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);
                    var filePath = Path.Combine(uploadsFolder, Path.GetFileName(companyDto.Logo));
                    await System.IO.File.WriteAllBytesAsync(filePath, companyDto.LogoBytes);
                }
            }
            catch
            {
            }

            if (companyDto.ID == 0)
            {
                var company = new Company()
                {
                    Name = companyDto.Name,
                    IsActive = companyDto.IsActive,
                    CheckInEmailTemplate = companyDto.CheckInEmailTemplate,
                    CheckOutEmailTemplate = companyDto.CheckOutEmailTemplate,
                    CurrencyID = companyDto.CurrencyID,
                    DesignatedEmail = companyDto.DesignatedEmail,
                    Logo = companyDto.Logo,
                    TermsAndConditionsMessage = companyDto.TermsAndConditionsMessage,
                    PartialCheckOutEmailTemplate = companyDto.PartialCheckOutEmailTemplate,
                    LogoBytes = companyDto.LogoBytes
                };
                _context.Companies.Add(company);
            }
            else
            {
                var dbCompany = await _context.Companies
                                  .FirstOrDefaultAsync(comp => comp.ID == companyDto.ID);
                if (dbCompany == null)
                    return CustomApiResponce.Error("Company does not exist");
                dbCompany.Name = companyDto.Name;
                dbCompany.IsActive = companyDto.IsActive;
                dbCompany.CheckInEmailTemplate = companyDto.CheckInEmailTemplate;
                dbCompany.CheckOutEmailTemplate = companyDto.CheckOutEmailTemplate;
                dbCompany.CurrencyID = companyDto.CurrencyID;
                dbCompany.DesignatedEmail = companyDto.DesignatedEmail;
                dbCompany.Logo = companyDto.Logo;
                dbCompany.TermsAndConditionsMessage = companyDto.TermsAndConditionsMessage;
                dbCompany.PartialCheckOutEmailTemplate = companyDto.PartialCheckOutEmailTemplate;
                dbCompany.LogoBytes = companyDto.LogoBytes;
                _context.Companies.Update(dbCompany);
            }
            await _context.SaveChangesAsync();
            return CustomApiResponce.Success();
        }
        public async Task<CompanyDto[]> GetCompaniesAsync() => await _context.Companies
                                                                              .Where(cmp => cmp.IsActive)
                                                                              .AsNoTracking()
                                                                              .Select(c => new CompanyDto
                                                                              {
                                                                                  ID = c.ID,
                                                                                  Name = c.Name,
                                                                                  CheckInEmailTemplate = c.CheckInEmailTemplate,
                                                                                  CheckOutEmailTemplate = c.CheckOutEmailTemplate,
                                                                                  CurrencyID = c.CurrencyID,
                                                                                  DesignatedEmail = c.DesignatedEmail,
                                                                                  Logo = c.Logo,
                                                                                  TermsAndConditionsMessage = c.TermsAndConditionsMessage,
                                                                                  PartialCheckOutEmailTemplate = c.PartialCheckOutEmailTemplate,
                                                                                  IsActive = c.IsActive,
                                                                              }).ToArrayAsync();
        public async Task<CompanyDto> GetCompanyByIDAsync(int companyID) => await _context.Companies
                                                                             .Where(cmp => cmp.IsActive
                                                                                           && cmp.ID == companyID)
                                                                             .AsNoTracking()
                                                                             .Select(c => new CompanyDto
                                                                             {
                                                                                 ID = c.ID,
                                                                                 Name = c.Name,
                                                                                 CheckInEmailTemplate = c.CheckInEmailTemplate,
                                                                                 CheckOutEmailTemplate = c.CheckOutEmailTemplate,
                                                                                 CurrencyID = c.CurrencyID,
                                                                                 DesignatedEmail = c.DesignatedEmail,
                                                                                 Logo = c.Logo,
                                                                                 TermsAndConditionsMessage = c.TermsAndConditionsMessage,
                                                                                 PartialCheckOutEmailTemplate = c.PartialCheckOutEmailTemplate,
                                                                                 IsActive = c.IsActive,
                                                                                 LogoBytes = c.LogoBytes
                                                                             }).FirstOrDefaultAsync();
    }
}
