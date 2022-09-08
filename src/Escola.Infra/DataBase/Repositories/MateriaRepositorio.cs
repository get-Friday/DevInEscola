﻿using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;

namespace Escola.Infra.DataBase.Repositories
{
    public class MateriaRepositorio : IMateriaRepositorio
    {
        private readonly EscolaDBContexto _contexto;
        public MateriaRepositorio(EscolaDBContexto contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Materia> ObterTodos()
        {
            return _contexto.Materias;
        }
        public Materia ObterPorId(Guid id)
        {
            return _contexto.Materias.Find(id);
        }
        public IEnumerable<Materia> ObterPorNome(string nome)
        {
            return _contexto.Materias
                .Where(m => m.Nome.Contains(nome));
        }
        public void Inserir(Materia materia)
        {
            _contexto.Materias.Add(materia);
            _contexto.SaveChanges();
        }
        public void Excluir(Materia materia)
        {
            _contexto.Materias.Remove(materia);
            _contexto.SaveChanges();
        }
        public void Alterar(Materia materia)
        {
            _contexto.Materias.Update(materia);
            _contexto.SaveChanges();
        }
        public bool ExisteMateria(string nome)
        {
            return _contexto.Materias.Any(m => m.Nome == nome);
        }
    }
}
