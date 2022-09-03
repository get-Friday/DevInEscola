using Escola.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Services
{
    public interface IBoletimServico
    {
        BoletimDTO ObterPorId(Guid guid);
        void Inserir(BoletimDTO boletim);
        void Excluir(Guid id);
        void Alterar(BoletimDTO boletim);
    }
}
