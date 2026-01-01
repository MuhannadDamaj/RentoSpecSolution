using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class CompanyEndpoints
    {
        public static IEndpointRouteBuilder MapCompanyEndPoints(this IEndpointRouteBuilder app)
        {
            var companyGroup = app.MapGroup("/api/companies").RequireAuthorization();
            companyGroup.MapGet("", async (CompanyService companyService) =>
            Results.Ok(await companyService.GetCompaniesAsync()));
            companyGroup.MapGet("{id:int}", async (int id,CompanyService companyService) =>
            Results.Ok(await companyService.GetCompanyByIDAsync(id)));
            companyGroup.MapPost("", async (CompanyDto dto, CompanyService companyService) =>
            Results.Ok(await companyService.SaveCompanyAsync(dto)))
                .RequireAuthorization(r => r.RequireRole(nameof(UserRoleEnum.Administrator)));
            return app;
        }
    }
}
