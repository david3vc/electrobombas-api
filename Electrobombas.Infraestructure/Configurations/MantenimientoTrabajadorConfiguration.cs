using Electrobombas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Infraestructure.Configurations
{
    public class MantenimientoTrabajadorConfiguration : IEntityTypeConfiguration<MantenimientoTrabajador>
    {
        public void Configure(EntityTypeBuilder<MantenimientoTrabajador> builder)
        {
            builder.ToTable("mantenimiento_trabajador");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_mantenimiento_trabajador");
            builder.Property(t => t.IdMantenimiento).HasColumnName("id_mantenimiento");
            builder.Property(t => t.IdTrabajador).HasColumnName("id_trabajador");
            builder.Property(t => t.FechaCreacion).HasColumnName("fecha_creacion");
            builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(one => one.Mantenimiento).WithMany(many => many.MantenimientoTrabajadores).HasForeignKey(fk => fk.IdMantenimiento);
            builder.HasOne(one => one.Trabajador).WithMany(many => many.MantenimientoTrabajadores).HasForeignKey(fk => fk.IdTrabajador);
        }
    }
}
