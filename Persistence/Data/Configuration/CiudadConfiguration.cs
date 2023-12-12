using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("ciudad");

        builder.HasIndex(e => e.IdDep, "IdDep");

        builder.Property(e => e.Nombre).HasMaxLength(100);

        builder.HasOne(d => d.IdDepNavigation).WithMany(p => p.Ciudads)
            .HasForeignKey(d => d.IdDep)
            .HasConstraintName("ciudad_ibfk_1");
    }
}