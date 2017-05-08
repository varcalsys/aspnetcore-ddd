using Microsoft.EntityFrameworkCore;
using SharedKernel.Models;

namespace Infra.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration) where TEntity : Entity
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
    }
}
