using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repositories
{
    public interface IMateriaRepositorio
    {
        IEnumerable<Materia> ObterTodos();
        Materia ObterPorId(Guid id);
        IEnumerable<Materia> ObterPorNome(string nome);
        void Inserir(Materia materia);
        void Excluir(Materia materia);
        void Alterar(Materia materia);
        bool ExisteMateria(string nome);
    }
}
