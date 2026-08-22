using Electrobombas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Electrobombas.Infraestructure.Configurations
{
    public class PozoConfiguration : IEntityTypeConfiguration<Pozo>
    {
        public void Configure(EntityTypeBuilder<Pozo> builder)
        {
            builder.ToTable("pozo");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_pozo");
            builder.Property(t => t.Nombre).HasColumnName("nombre");
            builder.Property(t => t.Diametro).HasColumnName("diametro");
            builder.Property(t => t.Ne).HasColumnName("ne");
            builder.Property(t => t.Profundidad).HasColumnName("profundidad");
            builder.Property(t => t.CantidadTubos).HasColumnName("cantidad_tubos");
            builder.Property(t => t.DiametroTubo).HasColumnName("diametro_tubo");
            builder.Property(t => t.Hp).HasColumnName("hp");
            builder.Property(t => t.Voltaje).HasColumnName("voltaje");
            builder.Property(t => t.Amperaje).HasColumnName("amperaje");
            builder.Property(t => t.Rpm).HasColumnName("rpm");
            builder.Property(t => t.CaudalLps).HasColumnName("caudal_lps");
            builder.Property(t => t.SerieMotor).HasColumnName("serie_motor");
            builder.Property(t => t.SerieBomba).HasColumnName("serie_bomba");
            builder.Property(t => t.NumeroImpulsores).HasColumnName("numero_impulsores");
            builder.Property(t => t.IdUbicacion).HasColumnName("id_ubicacion");
            builder.Property(t => t.FechaCreacion).HasColumnName("fecha_creacion");
            builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(one => one.Ubicacion).WithMany(many => many.Pozos).HasForeignKey(fk => fk.IdUbicacion);
        }
    }
}
