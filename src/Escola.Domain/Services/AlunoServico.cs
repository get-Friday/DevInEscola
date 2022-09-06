using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Domain.DTO;
using Escola.Domain.Models;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Exceptions;

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
            if(_alunoRepositorio.ExisteMatricula(aluno.Matricula))
                throw new DuplicadoException("Matricula já existente");

            _alunoRepositorio.Inserir(new Aluno(aluno));
        }

        public AlunoDTO ObterPorId(Guid id)
        {
            return new AlunoDTO(_alunoRepositorio.ObterPorId(id));
        }

        public IList<AlunoDTO> ObterTodos(Paginacao paginacao)
        {
            return _alunoRepositorio
                .ObterTodos(paginacao)
                .Select(a => new AlunoDTO(a))
                .ToList();
        }
        public void Alterar(AlunoDTO aluno)
        {
            Aluno alunoDb = _alunoRepositorio.ObterPorId(aluno.Id);
            alunoDb.Update(aluno);
            _alunoRepositorio.Alterar(alunoDb);
        }
        public int ObterTotal()
        {
            return _alunoRepositorio.ObterTotal();
        }
        public IList<BoletimDTO> ObterBoletins(Guid id)
        {
            IList<BoletimDTO> boletins = _alunoRepositorio
                .ObterBoletins(id)
                .Select(b => new BoletimDTO(b))
                .ToList();

            if (boletins == null)
                throw new InexistenteException("Aluno não encontrado");

            return boletins;
        }
        public IList<NotasMateriaDTO> ObterNotasMateria(Guid idAluno, Guid idBoletim)
        {
            return _alunoRepositorio.ObterNotasMateria(idAluno, idBoletim)
                .Select(nt => new NotasMateriaDTO(nt))
                .ToList();
        }
    }
}