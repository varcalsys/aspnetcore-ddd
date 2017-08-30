using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Dados.Comuns.Contextos
{
    public class EfContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public EfContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //DbSets

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration();
        }
    }
}
