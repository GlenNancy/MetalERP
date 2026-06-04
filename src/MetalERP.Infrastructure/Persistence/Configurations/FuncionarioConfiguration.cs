using MetalERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetalERP.Infrastructure.Persistence.Configurations;

public class FuncionarioConfiguration
    : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("Funcionarios");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Codigo)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(x => x.Codigo)
            .IsUnique();

        builder.Property(x => x.Apelido)
            .HasMaxLength(80);

        builder.Property(x => x.Ativo)
            .HasDefaultValue(true);

        builder.Property(x => x.Data_Criacao)
            .HasDefaultValueSql("NOW()");

        builder
            .HasOne(x => x.Setor)
            .WithMany(x => x.Funcionarios)
            .HasForeignKey(x => x.Setor_Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}