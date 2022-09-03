using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
