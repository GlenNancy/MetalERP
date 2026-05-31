using MetalERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetalERP.Infrastructure.Persistence.Configurations;

public class SetorConfiguration
    : IEntityTypeConfiguration<Setor>
{
    public void Configure(EntityTypeBuilder<Setor> builder)
    {
        builder.ToTable("Setores");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Tel_Setor)
            .HasMaxLength(20);

        builder.Property(x => x.Ativo)
            .HasDefaultValue(true);
    }
}