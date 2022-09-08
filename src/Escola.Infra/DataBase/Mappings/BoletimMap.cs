using Escola.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.HasOne<Aluno>(b => b.Aluno)
                .WithMany(a => a.Boletins)
                .HasForeignKey(b => b.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
