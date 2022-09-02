using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escola.Domain.DTO;
using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Services
{
    public interface IMateriaServico
    {
        IList<MateriaDTO> ObterTodos();
        MateriaDTO ObterPorId(Guid id);
        void Inserir(MateriaDTO materia);
        void Excluir(MateriaDTO materia);
        void Alterar(MateriaDTO materia);

    }
}
