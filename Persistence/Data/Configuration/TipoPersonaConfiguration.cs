using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration;

public class TipopersonaConfiguration : IEntityTypeConfiguration<Tipopersona>
{
    public void Configure(EntityTypeBuilder<Tipopersona> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("tipopersona");

        builder.Property(e => e.Descripcion).HasMaxLength(100);
    }
}