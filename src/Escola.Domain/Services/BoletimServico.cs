using Escola.Domain.DTO;
using Escola.Domain.Exceptions;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;
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
        public BoletimDTO ObterPorId(Guid id)
        {
            return new BoletimDTO(_boletimRepositorio.ObterPorId(id));
        }
        public void Inserir(BoletimDTO boletim)
        {
            _boletimRepositorio.Inserir(new Boletim(boletim));
        }
        public void Excluir(BoletimDTO boletim)
        {
            throw new NotImplementedException();
        }
        public void Alterar(BoletimDTO boletim)
        {
            if (!_boletimRepositorio.ExisteBoletim(boletim.Id))
                throw new InexistenteException("Boletim não encontrado");

            Boletim boletimDb = _boletimRepositorio.ObterPorId(boletim.Id);
            boletimDb.Update(boletim);
            _boletimRepositorio.Alterar(boletimDb);
        }
    }
}
