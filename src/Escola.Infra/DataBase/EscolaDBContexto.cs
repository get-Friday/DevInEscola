using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Escola.Domain.Models;
using Escola.Infra.DataBase.Mappings;

namespace Escola.Infra.DataBase
{
    public class EscolaDBContexto : DbContext
    {
        public DbSet<Aluno> Alunos {get; set; }
        public DbSet<Boletim> Boletins { get; set; }
        public DbSet<NotasMateria> NotasMateria { get; set; }
        public DbSet<Materia> Materias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EscolaDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new BoletimMap());
            modelBuilder.ApplyConfiguration(new NotasMateriaMap());
            modelBuilder.ApplyConfiguration(new MateriaMap());
        }
    }
}