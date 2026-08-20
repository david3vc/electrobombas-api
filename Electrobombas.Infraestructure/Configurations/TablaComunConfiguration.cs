using Electrobombas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Electrobombas.Infraestructure.Configurations
{
    public class TablaComunConfiguration : IEntityTypeConfiguration<TablaComun>
    {
        public void Configure(EntityTypeBuilder<TablaComun> builder)
        {
            builder.ToTable("tabla_comun");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_tabla_comun");
            builder.Property(t => t.IdTabla).HasColumnName("id_tabla");
            builder.Property(t => t.IdFila).HasColumnName("id_fila");
            builder.Property(t => t.Codigo).HasColumnName("codigo");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.FechaCreacion).HasColumnName("fecha_creacion");
            builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
