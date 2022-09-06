using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        IEnumerable<Boletim> ObterBoletins(Guid id);
        IEnumerable<NotasMateria> ObterNotasMateria(Guid idAluno, Guid idBoletim);
    }
}