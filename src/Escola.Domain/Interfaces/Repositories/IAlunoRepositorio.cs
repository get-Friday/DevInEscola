using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repositories
{
    public interface IAlunoRepositorio
    {
        IEnumerable<Aluno> ObterTodos(Paginacao paginacao);
        Aluno ObterPorId(Guid id);
        void Inserir(Aluno aluno);
        void Excluir (Aluno aluno);
        void Alterar (Aluno aluno);
        bool ExisteMatricula (int matricula);
        public int ObterTotal();
    }
}