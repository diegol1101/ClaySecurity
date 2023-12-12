using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("departamento");

        builder.HasIndex(e => e.IdPais, "IdPais");

        builder.Property(e => e.Nombre).HasMaxLength(100);

        builder.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Departamentos)
            .HasForeignKey(d => d.IdPais)
            .HasConstraintName("departamento_ibfk_1");
    }
}