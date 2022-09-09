using Escola.Domain.DTO.V1;
using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Services
{
    public interface IMateriaServico
    {
        IList<MateriaDTO> ObterTodos(Paginacao paginacao);
        MateriaDTO ObterPorId(Guid id);
        IList<MateriaDTO> ObterPorNome(string nome);
        void Inserir(MateriaDTO materia);
        void Excluir(Guid id);
        void Alterar(MateriaDTO materia);
        int ObterTotal();
    }
}
