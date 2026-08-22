using Electrobombas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Infraestructure.Configurations
{
    public class MantenimientoConfiguration : IEntityTypeConfiguration<Mantenimiento>
    {
        public void Configure(EntityTypeBuilder<Mantenimiento> builder)
        {
            builder.ToTable("mantenimiento");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_mantenimiento");
            builder.Property(t => t.Fecha).HasColumnName("fecha");
            builder.Property(t => t.IdPozo).HasColumnName("id_pozo");
            builder.Property(t => t.IdTipoMantenimiento).HasColumnName("id_tipo_mantenimiento");
            builder.Property(t => t.Observaciones).HasColumnName("observaciones");
            builder.Property(t => t.FechaCreacion).HasColumnName("fecha_creacion");
            builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(one => one.TipoMantenimiento).WithMany(many => many.Mantenimientos).HasForeignKey(fk => fk.IdTipoMantenimiento);
            builder.HasOne(one => one.Pozo).WithMany(many => many.Mantenimientos).HasForeignKey(fk => fk.IdPozo);
        }
    }
}
