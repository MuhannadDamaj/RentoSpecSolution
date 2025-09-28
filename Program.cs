using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    string? secretKey = builder.Configuration.GetValue<string>("Jwt:Secret");
    var symmetricKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey == null ? string.Empty : secretKey));
    var issuer = builder.Configuration.GetValue<string>("Jwt:Issuer");
    var audience = builder.Configuration.GetValue<string>("Jwt:Audience");
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
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
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//builder.Services.AddCors(options =>
//{
//    var allowedOriginsString = builder.Configuration.GetValue<string>("AllowedOrigins");
//    var allowedOrigins = allowedOriginsString.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
//    options.AddDefaultPolicy(p => p.WithOrigins(allowedOriginsString)
//                                    .AllowAnyHeader()
//                                    .AllowAnyMethod());
//});


builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();
app.UseStaticFiles();
#if DEBUG
ApplyDBMigrations(app.Services);
#endif

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors();
app.UseAuthentication().UseAuthorization();
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
   .MapUploadEndPoints();
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
