using Electrobombas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Infraestructure.Configurations
{
    public class MedicionMantenimientoConfiguration : IEntityTypeConfiguration<MedicionMantenimiento>
    {
        public void Configure(EntityTypeBuilder<MedicionMantenimiento> builder)
        {
            builder.ToTable("medicion_mantenimiento");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_medicion_mantenimiento");
            builder.Property(t => t.IdMantenimiento).HasColumnName("id_mantenimiento");
            builder.Property(t => t.NivelEstatico).HasColumnName("nivel_estatico");
            builder.Property(t => t.Profundidad).HasColumnName("profundidad");
            builder.Property(t => t.CantidadTubos).HasColumnName("cantidad_tubos");
            builder.Property(t => t.DiametroTubo).HasColumnName("diametro_tubo");
            builder.Property(t => t.Voltaje).HasColumnName("voltaje");
            builder.Property(t => t.Amperaje).HasColumnName("amperaje");
            builder.Property(t => t.CaudalLps).HasColumnName("caudal_lps");
            builder.Property(t => t.NumeroImpulsores).HasColumnName("numero_impulsores");
            builder.Property(t => t.FechaCreacion).HasColumnName("fecha_creacion");
            builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(one => one.Mantenimiento).WithOne(one => one.MedicionMantenimiento).HasForeignKey<MedicionMantenimiento>(fk => fk.IdMantenimiento);
        }
    }
}
