using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Services
{
    public class BoletimServico : IBoletimServico
    {
        private readonly IBoletimRepositorio _boletimRepositorio;
        public BoletimServico(IBoletimRepositorio boletimRepositorio)
        {
            _boletimRepositorio = boletimRepositorio;
        }
        public BoletimDTO ObterPorId(Guid guid)
        {
            throw new NotImplementedException();
        }
        public void Inserir(BoletimDTO boletim)
        {
            throw new NotImplementedException();
        }
        public void Excluir(BoletimDTO boletim)
        {
            throw new NotImplementedException();
        }
        public void Alterar(BoletimDTO boletim)
        {
            throw new NotImplementedException();
        }
    }
}
