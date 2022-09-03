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
        public Boletim ObterPorId(Guid id)
        {
            return _contexto.Boletins.Find(id);
        }
        public void Inserir(Boletim boletim)
        {
            _contexto.Boletins.Add(boletim);
            _contexto.SaveChanges();
        }
        public void Excluir(Boletim boletim)
        {
            throw new NotImplementedException();
        }
        public void Alterar(Boletim boletim)
        {
            _contexto.Boletins.Update(boletim);
            _contexto.SaveChanges();
        }
        public bool ExisteBoletim(Guid id)
        {
            return _contexto.Boletins.Any(b => b.Id == id);
        }
    }
}
