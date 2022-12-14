using Escola.Domain.DTO.V1;
using Escola.Domain.Exceptions;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;

namespace Escola.Domain.Services
{
    public class MateriaServico : IMateriaServico
    {
        private readonly IMateriaRepositorio _materiaRepositorio;
        public MateriaServico(IMateriaRepositorio materiaRepositorio)
        {
            _materiaRepositorio = materiaRepositorio;
        }
        public IList<MateriaDTO> ObterTodos(Paginacao paginacao)
        {
            return _materiaRepositorio
                .ObterTodos(paginacao)
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
            if (!_materiaRepositorio.ExisteMateria(materia.Nome))
                throw new InexistenteException("Materia não encontrada");

            Materia materiaDb = _materiaRepositorio.ObterPorId(materia.Id);
            materiaDb.Update(materia);
            _materiaRepositorio.Alterar(materiaDb);
        }
        public int ObterTotal()
        {
            return _materiaRepositorio.ObterTotal();
        }
    }
}
