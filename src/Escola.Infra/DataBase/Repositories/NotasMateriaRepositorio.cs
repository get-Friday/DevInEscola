using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.DataBase.Repositories
{
    public class NotasMateriaRepositorio : INotasMateriaRepositorio
    {
        private readonly EscolaDBContexto _contexto;
        public NotasMateriaRepositorio(EscolaDBContexto contexto)
        {
            _contexto = contexto;
        }
        public NotasMateria ObterPorId(Guid id)
        {
            return _contexto.NotasMateria.Find(id);
        }
        public void Inserir(NotasMateria notasMateria)
        {
            _contexto.NotasMateria.Add(notasMateria);
            _contexto.SaveChanges();
        }
        public void Excluir(NotasMateria notasMateria)
        {
            throw new NotImplementedException();
        }
        public void Alterar(NotasMateria notasMateria)
        {
            throw new NotImplementedException();
        }
    }
}
