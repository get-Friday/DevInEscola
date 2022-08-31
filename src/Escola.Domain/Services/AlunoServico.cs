using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Domain.DTO;
using Escola.Domain.Models;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;

namespace Escola.Domain.Services
{
    public class AlunoServico : IAlunoServico
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoServico(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }
        public void Excluir(Guid id)
        {
            Aluno aluno = _alunoRepositorio.ObterPorId(id);
            _alunoRepositorio.Excluir(aluno);
        }

        public void Inserir(AlunoDTO aluno)
        {
            _alunoRepositorio.Inserir(new Aluno(aluno));
        }

        public AlunoDTO ObterPorId(Guid id)
        {
            return new AlunoDTO(_alunoRepositorio.ObterPorId(id));
        }

        public IList<AlunoDTO> ObterTodos()
        {
            IList<AlunoDTO> alunos = _alunoRepositorio
                .ObterTodos()
                .Select(a => new AlunoDTO(a))
                .ToList();

            return alunos;
        }

        public void Alterar(Guid id, AlunoDTO alteracao)
        {
            AlunoDTO aluno = new(_alunoRepositorio.ObterPorId(id));

            aluno.Nome = alteracao.Nome;
            aluno.Sobrenome = alteracao.Sobrenome;
            aluno.DataNascimento = alteracao.DataNascimento;
            aluno.Matricula = alteracao.Matricula;
            aluno.Email = alteracao.Email;

            _alunoRepositorio.Alterar();
        }
    }
}