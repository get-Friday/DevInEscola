using Escola.Domain.DTO.V1;

namespace Escola.Domain.Interfaces.Services
{
    public interface IMateriaServico
    {
        IList<MateriaDTO> ObterTodos();
        MateriaDTO ObterPorId(Guid id);
        IList<MateriaDTO> ObterPorNome(string nome);
        void Inserir(MateriaDTO materia);
        void Excluir(Guid id);
        void Alterar(MateriaDTO materia);

    }
}
