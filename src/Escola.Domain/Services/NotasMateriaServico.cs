using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Services
{
    public class NotasMateriaServico : INotasMateriaServico
    {
        private readonly INotasMateriaRepositorio _notasMateriaRepositorio;
        public NotasMateriaServico(INotasMateriaRepositorio notasMateriaRepositorio)
        {
            _notasMateriaRepositorio = notasMateriaRepositorio;
        }
        public NotasMateriaDTO ObterPorId(Guid id)
        {
            return new NotasMateriaDTO(_notasMateriaRepositorio.ObterPorId(id));
        }
        public void Inserir(NotasMateriaDTO notasMateria)
        {
            _notasMateriaRepositorio.Inserir(new NotasMateria(notasMateria));
        }
        public void Excluir(Guid id)
        {
            throw new NotImplementedException();
        }
        public void Alterar(NotasMateriaDTO notasMateria)
        {
            NotasMateria notasMateriaDb = _notasMateriaRepositorio.ObterPorId(notasMateria.Id);
            notasMateriaDb.Update(notasMateria);
            _notasMateriaRepositorio.Alterar(notasMateriaDb);
        }
    }
}
