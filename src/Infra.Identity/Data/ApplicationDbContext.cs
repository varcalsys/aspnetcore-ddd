using Infra.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfigurationRoot _configuration;

      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfigurationRoot configuration)
            : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRoleClaim<string>>()
                .ToTable("RoleClaims", "Identity");
            builder.Entity<IdentityRole>()
                .ToTable("Roles", "Identity");
            builder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaims", "Identity");
            builder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins", "Identity")
                .HasKey(x => x.UserId); ;
            builder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles", "Identity")
                .HasKey(x => new { x.UserId, x.RoleId }); ;
            builder.Entity<ApplicationUser>()
                .ToTable("User", "Identity");
            builder.Entity<IdentityUserToken<string>>()
                .ToTable("UserTokens", "Identity")
                .HasKey(x => x.UserId);
        }
    }
}
