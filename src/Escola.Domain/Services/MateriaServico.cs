using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;
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
            throw new NotImplementedException();
        }
        public void Inserir(MateriaDTO materia)
        {
            throw new NotImplementedException();
        }
        public void Excluir(MateriaDTO materia)
        {
            throw new NotImplementedException();
        }
        public void Alterar(MateriaDTO materia)
        {
            throw new NotImplementedException();
        }
    }
}
