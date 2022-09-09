using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.DataBase.Repositories
{
    public class BaseRepositorio <TEntity, TKey> where TEntity : class
    {
        protected readonly EscolaDBContexto _contexto;
        public BaseRepositorio(EscolaDBContexto contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<TEntity> ObterTodos(Paginacao paginacao)
        {
            return _contexto.Set<TEntity>()
                .Take(paginacao.Take)
                .Skip(paginacao.Skip);
        }
        public TEntity ObterPorId(TKey key)
        {
            return _contexto.Set<TEntity>().Find(key);
        }
        public void Inserir(TEntity entity)
        {
            _contexto.Set<TEntity>().Add(entity);
            _contexto.SaveChanges();
        }
        public void Alterar(TEntity entity)
        {
            _contexto.Set<TEntity>().Update(entity);
            _contexto.SaveChanges();
        }
        public void Excluir(TEntity entity)
        {
            _contexto.Set<TEntity>().Remove(entity);
            _contexto.SaveChanges();
        }
    }
}
