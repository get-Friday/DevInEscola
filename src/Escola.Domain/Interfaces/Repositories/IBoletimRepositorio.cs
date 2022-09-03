using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Repositories
{
    public interface IBoletimRepositorio
    {
        Boletim ObterPorId(Guid id);
        void Inserir(Boletim boletim);
        void Excluir(Boletim boletim);
        void Alterar(Boletim boletim);
        bool ExisteBoletim(Guid id);
    }
}
