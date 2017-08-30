using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NucleoCompartilhado.Models.BaseObjects;

namespace Infra.Dados.Comuns.Mapeamentos.Base
{
    public abstract class BaseMap<TEntity>: IEntityTypeConfiguration<TEntity> where TEntity: Entidade
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime2(3)")
                .IsRequired();

            builder.Property(x => x.Ativo)
                .HasColumnName("Ativo")
                .HasColumnType("bit")
                .IsRequired();

        }
    }
}
