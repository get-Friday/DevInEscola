using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;

namespace Escola.Infra.DataBase.Repositories
{
    public class MateriaRepositorio : BaseRepositorio<Materia, Guid>, IMateriaRepositorio
    {
        public MateriaRepositorio(EscolaDBContexto contexto) : base(contexto)
        {
        }
        public IEnumerable<Materia> ObterPorNome(string nome)
        {
            return _contexto.Materias
                .Where(m => m.Nome.Contains(nome));
        }
        public bool ExisteMateria(string nome)
        {
            return _contexto.Materias.Any(m => m.Nome.Contains(nome));
        }
        public int ObterTotal()
        {
            return _contexto.Materias.Count();
        }
    }
}
