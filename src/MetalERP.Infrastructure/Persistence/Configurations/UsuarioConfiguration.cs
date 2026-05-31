using MetalERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetalERP.Infrastructure.Persistence.Configurations;

public class UsuarioConfiguration
    : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.Senha_Hash)
            .IsRequired();

        builder.Property(x => x.Ativo)
            .HasDefaultValue(true);

        builder.Property(x => x.Data_Criacao)
            .HasDefaultValueSql("NOW()");

        builder
            .HasOne(x => x.Setor)
            .WithMany(x => x.Usuarios)
            .HasForeignKey(x => x.Setor_Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}