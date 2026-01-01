using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Entities.AiEntities;
using System.Security.Claims;

namespace RentospectWebAPI.Data.Rentospect
{
    public class RentospectContext : DbContext
    {
        public RentospectContext(DbContextOptions<RentospectContext> options,
                                 IPasswordHasher<User> passwordHasher,
                                 IHttpContextAccessor _httpContextAccessor) : base(options)
        {
            _passwordHasher = passwordHasher;
            this._httpContextAccessor = _httpContextAccessor;
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<CarClassDamage> CarClassDamages { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Damage> Damages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<InspectionDamage> InspectionDamages { get; set; }
        public DbSet<InspectionImage> InspectionImages { get; set; }
        public DbSet<InspectionSignature> InspectionSignatures { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<InspectionType> InspectionTypes { get; set; }
        public DbSet<InspectionResult> InspectionResults { get; set; }
        public DbSet<DamagedPart> DamagedParts { get; set; }
        public DbSet<AILog>  aILogs { get; set; }

        public IPasswordHasher<User> _passwordHasher { get; }
        public IHttpContextAccessor _httpContextAccessor { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            base.OnConfiguring(dbContextOptionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            User user = new User()
            {
                ID = 1,
                FullName = "Muhannad Damaj",
                Email = "m@gmail.com",
                PhoneNumber = "70970173",
                Role = nameof(UserRole.UserRoleEnum.Administrator),
                CompanyID = 3,
            };
            var z = _passwordHasher.HashPassword(user, "123456");
            //        modelBuilder.Entity<Currency>().HasData(
            //    new Currency { ID = 1, 
            //                   Name = "US Dollar", 
            //        Symbol = "USD", 
            //        IsActive = true,
            //    CreatedAt = new DateTime(2020,02,01),
            //    CreatedBy = "Muhannad Damaj",
            //    UpdatedAt = new DateTime(2020, 02, 01),
            //    UpdatedBy = "Muhannad Damaj"});
            //        modelBuilder.Entity<Company>().HasData(
            //    new Company
            //    {
            //        ID = 1,
            //        Name = "Rentospect Solutions",
            //        Logo = "logo.png",
            //        LogoBytes = new byte[] { 0x42, 0x4D, 0x46, 0x01, 0x02 }, // sample binary
            //        DesignatedEmail = "info@rentospect.com",
            //        TermsAndConditionsMessage = "Default terms...",
            //        CheckInEmailTemplate = "Welcome to check-in!",
            //        CheckOutEmailTemplate = "Thank you for checking out!",
            //        PartialCheckOutEmailTemplate = "Partial checkout info",
            //        IsActive = true,
            //        CurrencyID = 1, // link to USD
            //        CreatedAt = new DateTime(2020, 02, 01),
            //        CreatedBy = "Muhannad Damaj",
            //        UpdatedAt = new DateTime(2020, 02, 01),
            //        UpdatedBy = "Muhannad Damaj"
            //    }
            //    }
            //);
        }
        public override int SaveChanges()
        {
            ApplyAuditInformation();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInformation()
        {
            var userName = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name)
                           ?? "System"; // fallback if no user

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = userName;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = userName;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = userName;
                }
            }
        }

    }
}
