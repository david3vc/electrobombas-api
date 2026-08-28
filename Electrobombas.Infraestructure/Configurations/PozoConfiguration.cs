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
            builder.Property(t => t.Numero).HasColumnName("numero");
            builder.Property(t => t.Diametro).HasColumnName("diametro");
            builder.Property(t => t.HpActual).HasColumnName("hp_actual");
            builder.Property(t => t.RpmActual).HasColumnName("rpm_actual");
            builder.Property(t => t.SerieMotorActual).HasColumnName("serie_motor_actual");
            builder.Property(t => t.SerieBombaActual).HasColumnName("serie_bomba_actual");
            builder.Property(t => t.IdUbicacion).HasColumnName("id_ubicacion");
            builder.Property(t => t.FechaCreacion).HasColumnName("fecha_creacion");
            builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(one => one.Ubicacion).WithMany(many => many.Pozos).HasForeignKey(fk => fk.IdUbicacion);
        }
    }
}
