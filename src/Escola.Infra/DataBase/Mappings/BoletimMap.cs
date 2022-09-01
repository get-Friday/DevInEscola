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
    public class BoletimMap : IEntityTypeConfiguration<Boletim>
    {
        public void Configure(EntityTypeBuilder<Boletim> builder)
        {
            builder.ToTable("BOLETIM");

            builder.HasKey(b => b.Id)
                .HasName("PK_BoletimID");

            builder.Property(b => b.Id)
                .HasColumnName("ID")
                .HasColumnType("uniqueidentifier");

            builder.Property(b => b.AlunoId)
                .HasColumnName("AlunoID")
                .HasColumnType("uniqueidentifier");

            builder.HasOne<Aluno>(b => b.Aluno)
                .WithMany(a => a.Boletins)
                .HasForeignKey(b => b.AlunoId);
        }
    }
}
