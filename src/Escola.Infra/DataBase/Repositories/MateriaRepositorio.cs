using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escola.Domain.Interfaces.Repositories;
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
            _contexto.Add(materia);
            _contexto.SaveChanges();
        }
        public void Excluir(Materia materia)
        {
            throw new NotImplementedException();
        }
        public void Alterar(Materia materia)
        {
            throw new NotImplementedException();
        }
        public bool ExisteMateria(string materia)
        {
            return _contexto.Materias.Any(m => m.Nome == materia);
        }
    }
}
