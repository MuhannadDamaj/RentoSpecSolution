using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Refit;
using RentospectShared.API;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;
using RentospectWebAPI.Endpoints;
using RentospectWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Add EF Core with SQL Server
builder.Services.AddDbContext<RentospectContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

// Add Identity password hasher
builder.Services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<CurrencyService>();
builder.Services.AddTransient<CompanyService>();
builder.Services.AddTransient<BranchService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<CarClassService>();
builder.Services.AddTransient<CarMakeService>();
builder.Services.AddTransient<CarModelService>();
builder.Services.AddTransient<CarCategoryService>();
builder.Services.AddTransient<CarService>();
builder.Services.AddTransient<DamageService>();
builder.Services.AddTransient<UploadImageService>();
builder.Services.AddTransient<CarClassDamageService>();
builder.Services.AddTransient<UploadService>();
builder.Services.AddTransient<MasterSyncService>();
builder.Services.AddTransient<InspectionTypeService>();
builder.Services.AddTransient<InspectionService>();
builder.Services.AddTransient<InspektAuthService>();
builder.Services.AddTransient<AIService>();
builder.Services.AddTransient<AiPayloadService>();
builder.Services.AddTransient<PortalInspectionService>();
builder.Services.AddTransient<InspectionResultService>();
builder.Services.AddTransient<UpdateInspectionService>();

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    string? secretKey = builder.Configuration.GetValue<string>("Jwt:Secret");
    var symmetricKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey ?? string.Empty));
    var issuer = builder.Configuration.GetValue<string>("Jwt:Issuer");
    var audience = builder.Configuration.GetValue<string>("Jwt:Audience");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = symmetricKey,
        ValidIssuer = issuer,
        ValidAudience = audience,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
    };
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", policy =>
    {
        policy.WithOrigins(
                "https://rentospectwebappwasm-aqaqgrfmh8cffcbk.uaenorth-01.azurewebsites.net",
                "http://localhost:5044",
                "https://localhost:7233"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // keep credentials enabled
    });
});


builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRefitClient<IInspektAuthApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://reports.inspektlabs.com"));
builder.Services.AddRefitClient<IInspektAI>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://reports.inspektlabs.com")); // or AI base URL

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = 200_000_000; // 200 MB
});

var app = builder.Build();

app.UseHttpsRedirection();

// ✅ Use CORS before authentication
app.UseCors("BlazorPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

#if DEBUG
ApplyDBMigrations(app.Services);
#endif

app.MapControllers();

app.MapAuthEndpoints()
   .MapCurrencyEndPoints()
   .MapCompanyEndPoints()
   .MapBranchEndPoints()
   .MapUserEndPoints()
   .MapCarClassEndPoints()
   .MapCarCategoryEndPoints()
   .MapCarMakeEndPoints()
   .MapCarModelEndPoints()
   .MapCarEndPoints()
   .MapDamageEndPoints()
   .MapUploadImageEndpoints()
   .MapCarClassDamageEndPoints()
   .MapUploadEndPoints()
   .MapMasterSyncEndPoints()
   .MapInspectionTypeEndPoints()
   .MapInspectionEndPoints()
   .MapAiPayloadEndpoints()
   .MapPortalInspectionEndpoints()
   .MapInspectionResultEndPoints()
   .MapInspectionUpdateEndPoints();


app.Run();

static void ApplyDBMigrations(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<RentospectContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}
