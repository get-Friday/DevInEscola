using Escola.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.DataBase.Mappings
{
    public class NotasMateriaMap : IEntityTypeConfiguration<NotasMateria>
    {
        public void Configure(EntityTypeBuilder<NotasMateria> builder)
        {
            builder.ToTable("NOTAS_MATERIA");

            builder.HasKey(nt => nt.Id)
                .HasName("PK_NotasMateriaID");

            builder.Property(nt => nt.Id)
                .HasColumnName("ID")
                .HasColumnType("uniqueidentifier");

            builder.Property(nt => nt.Nota)
                .HasColumnName("NOTA")
                .HasColumnType("int");

            builder.HasOne<Boletim>(nt => nt.Boletim)
                .WithMany(b => b.NotasMateria)
                .HasForeignKey(nt => nt.BoletimId);

            builder.HasOne<Materia>(nt => nt.Materia)
                .WithMany()
                .HasForeignKey(nt => nt.MateriaId);
        }
    }
}
