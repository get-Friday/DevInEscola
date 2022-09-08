using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Domain.DTO.V1;
using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Services
{
    public interface IAlunoServico
    {
        IList<AlunoDTO> ObterTodos(Paginacao paginacao);
        AlunoDTO ObterPorId(Guid id);
        void Inserir(AlunoDTO aluno);
        void Excluir (Guid id);
        void Alterar (AlunoDTO alteracao);
        public int ObterTotal();
    }
}