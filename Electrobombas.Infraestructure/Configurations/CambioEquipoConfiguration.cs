using Electrobombas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Infraestructure.Configurations
{
    public class CambioEquipoConfiguration : IEntityTypeConfiguration<CambioEquipo>
    {
        public void Configure(EntityTypeBuilder<CambioEquipo> builder)
        {
            builder.ToTable("cambio_equipo");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_cambio_equipo");
            builder.Property(t => t.IdMantenimiento).HasColumnName("id_mantenimiento");
            builder.Property(t => t.IdTipoEquipo).HasColumnName("id_tipo_equipo");
            builder.Property(t => t.MotorMarcaActualAnterior).HasColumnName("motor_marca_actual_anterior");
            builder.Property(t => t.MotorMarcaActualNuevo).HasColumnName("motor_marca_actual_nuevo");
            builder.Property(t => t.SerieAnterior).HasColumnName("serie_anterior");
            builder.Property(t => t.SerieNuevo).HasColumnName("serie_nueva");
            builder.Property(t => t.HpAnterior).HasColumnName("hp_anterior");
            builder.Property(t => t.HpNuevo).HasColumnName("hp_nuevo");
            builder.Property(t => t.RpmAnterior).HasColumnName("rpm_anterior");
            builder.Property(t => t.RpmNuevo).HasColumnName("rpm_nuevo");
            builder.Property(t => t.Observacion).HasColumnName("observacion");
            builder.Property(t => t.FechaCreacion).HasColumnName("fecha_creacion");
            builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(one => one.Mantenimiento).WithMany(many => many.CambioEquipos).HasForeignKey(fk => fk.IdMantenimiento);
            builder.HasOne(one => one.TipoEquipo).WithMany(many => many.CambioEquipos).HasForeignKey(fk => fk.IdTipoEquipo);
        }
    }
}
