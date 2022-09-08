using Escola.Domain.DTO.V1;
using Escola.Domain.Exceptions;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;

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
            if (!_notasMateriaRepositorio.ExisteNotasMateria(id))
                throw new InexistenteException("NotasMateria não encontrado");

            NotasMateria notasMateria = _notasMateriaRepositorio.ObterPorId(id);
            _notasMateriaRepositorio.Excluir(notasMateria);
        }
        public void Alterar(NotasMateriaDTO notasMateria)
        {
            if (!_notasMateriaRepositorio.ExisteNotasMateria(notasMateria.Id))
                throw new InexistenteException("NotasMateria não encontrado");

            NotasMateria notasMateriaDb = _notasMateriaRepositorio.ObterPorId(notasMateria.Id);
            notasMateriaDb.Update(notasMateria);
            _notasMateriaRepositorio.Alterar(notasMateriaDb);
        }
    }
}
