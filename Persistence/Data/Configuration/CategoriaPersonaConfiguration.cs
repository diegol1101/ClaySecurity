using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration;

public class CategoriapersonaConfiguration : IEntityTypeConfiguration<Categoriapersona>
{
    public void Configure(EntityTypeBuilder<Categoriapersona> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("categoriapersona");

        builder.Property(e => e.Nombre).HasMaxLength(100);
    }
}