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
    public class MateriaServico : IMateriaServico
    {
        private readonly IMateriaRepositorio _materiaRepositorio;
        public MateriaServico(IMateriaRepositorio materiaRepositorio)
        {
            _materiaRepositorio = materiaRepositorio;
        }
        public IList<MateriaDTO> ObterTodos()
        {
            return _materiaRepositorio
                .ObterTodos()
                .Select(m => new MateriaDTO(m))
                .ToList();
        }
        public MateriaDTO ObterPorId(Guid id)
        {
            return new MateriaDTO(_materiaRepositorio.ObterPorId(id));
        }
        public IList<MateriaDTO> ObterPorNome(string nome)
        {
            var materias = _materiaRepositorio
                .ObterPorNome(nome)
                .Select(m => new MateriaDTO(m))
                .ToList();

            if (!materias.Any())
                throw new InexistenteException("Matéria não encontrada");

            return materias;
        }
        public void Inserir(MateriaDTO materia)
        {
            if (_materiaRepositorio.ExisteMateria(materia.Nome))
                throw new DuplicadoException("Materia já existe");

            _materiaRepositorio.Inserir(new Materia(materia));
        }
        public void Excluir(Guid id)
        {
            Materia materia = _materiaRepositorio.ObterPorId(id);

            if (materia == null)
                throw new InexistenteException("Matéria não encontrada");

            _materiaRepositorio.Excluir(materia);
        }
        public void Alterar(MateriaDTO materia)
        {
            throw new NotImplementedException();
        }
    }
}
