using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repositories
{
    public interface INotasMateriaRepositorio
    {
        public NotasMateria ObterPorId(Guid id);
        public void Inserir(NotasMateria notasMateria);
        public void Excluir(NotasMateria notasMateria);
        public void Alterar(NotasMateria notasMateria);
        public bool ExisteNotasMateria(Guid id);
    }
}
