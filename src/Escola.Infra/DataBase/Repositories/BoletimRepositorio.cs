using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;

namespace Escola.Infra.DataBase.Repositories
{
    public class BoletimRepositorio : BaseRepositorio<Boletim, Guid>, IBoletimRepositorio
    {
        public BoletimRepositorio(EscolaDBContexto contexto) : base(contexto)
        {
        }
        public bool ExisteBoletim(Guid id)
        {
            return _contexto.Boletins.Any(b => b.Id == id);
        }
        public IEnumerable<Boletim> ObterBoletins(Guid id)
        {
            return _contexto.Boletins.Where(b => b.AlunoId == id);
        }
        public IEnumerable<NotasMateria> ObterNotasMateria(Guid idAluno, Guid idBoletim)
        {
            return _contexto.NotasMateria.Where(nt => nt.Boletim.AlunoId == idAluno && nt.BoletimId == idBoletim);
        }
    }
}
