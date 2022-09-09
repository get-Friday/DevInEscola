using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;

namespace Escola.Infra.DataBase.Repositories
{
    public class NotasMateriaRepositorio : BaseRepositorio<NotasMateria, Guid>, INotasMateriaRepositorio
    {
        public NotasMateriaRepositorio(EscolaDBContexto contexto) : base(contexto)
        {
        }
        public bool ExisteNotasMateria(Guid id)
        {
            return _contexto.NotasMateria.Any(nt => nt.Id == id);
        }
    }
}
