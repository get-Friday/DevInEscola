using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repositories
{
    public interface IBoletimRepositorio
    {
        Boletim ObterPorId(Guid id);
        void Inserir(Boletim boletim);
        void Excluir(Boletim boletim);
        void Alterar(Boletim boletim);
        bool ExisteBoletim(Guid id);
        IEnumerable<Boletim> ObterBoletins(Guid id);
        IEnumerable<NotasMateria> ObterNotasMateria(Guid idAluno, Guid idBoletim);
    }
}
