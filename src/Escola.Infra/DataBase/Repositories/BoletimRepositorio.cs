using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;

namespace Escola.Infra.DataBase.Repositories
{
    public class BoletimRepositorio : IBoletimRepositorio
    {
        private readonly EscolaDBContexto _contexto;
        public BoletimRepositorio(EscolaDBContexto contexto)
        {
            _contexto = contexto;
        }
        public Boletim ObterPorId(Guid guid)
        {
            throw new NotImplementedException();
        }
        public void Inserir(Boletim boletim)
        {
            throw new NotImplementedException();
        }
        public void Excluir(Boletim boletim)
        {
            throw new NotImplementedException();
        }
        public void Alterar(Boletim boletim)
        {
            throw new NotImplementedException();
        }
    }
}
