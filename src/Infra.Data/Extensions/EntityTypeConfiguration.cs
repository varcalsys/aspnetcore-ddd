using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Models;

namespace Infra.Data.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity: Entity
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
