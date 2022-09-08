using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;

namespace Escola.Infra.DataBase.Repositories
{
    public class NotasMateriaRepositorio : INotasMateriaRepositorio
    {
        private readonly EscolaDBContexto _contexto;
        public NotasMateriaRepositorio(EscolaDBContexto contexto)
        {
            _contexto = contexto;
        }
        public NotasMateria ObterPorId(Guid id)
        {
            return _contexto.NotasMateria.Find(id);
        }
        public void Inserir(NotasMateria notasMateria)
        {
            _contexto.NotasMateria.Add(notasMateria);
            _contexto.SaveChanges();
        }
        public void Excluir(NotasMateria notasMateria)
        {
            _contexto.NotasMateria.Remove(notasMateria);
            _contexto.SaveChanges();
        }
        public void Alterar(NotasMateria notasMateria)
        {
            _contexto.NotasMateria.Update(notasMateria);
            _contexto.SaveChanges();
        }
        public bool ExisteNotasMateria(Guid id)
        {
            return _contexto.NotasMateria.Any(nt => nt.Id == id);
        }
    }
}
