using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Contexts
{
    public class EfContext: DbContext
    {
        private readonly IConfigurationRoot _configuration;

        public EfContext(DbContextOptions options, IConfigurationRoot configuration)
            :base(options)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connecitionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connecitionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
