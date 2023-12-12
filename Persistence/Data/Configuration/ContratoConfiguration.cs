using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration;

public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("contrato");

        builder.HasIndex(e => e.IdCliente, "IdCliente");

        builder.HasIndex(e => e.IdEmpleado, "IdEmpleado");

        builder.HasIndex(e => e.IdEstado, "IdEstado");

        builder.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ContratoIdClienteNavigations)
            .HasForeignKey(d => d.IdCliente)
            .HasConstraintName("contrato_ibfk_1");

        builder.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.ContratoIdEmpleadoNavigations)
            .HasForeignKey(d => d.IdEmpleado)
            .HasConstraintName("contrato_ibfk_2");

        builder.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Contratos)
            .HasForeignKey(d => d.IdEstado)
            .HasConstraintName("contrato_ibfk_3");
    }
}