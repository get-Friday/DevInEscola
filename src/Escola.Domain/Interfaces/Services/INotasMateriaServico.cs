using Escola.Domain.DTO.V1;

namespace Escola.Domain.Interfaces.Services
{
    public interface INotasMateriaServico
    {
        public NotasMateriaDTO ObterPorId(Guid id);
        public void Inserir(NotasMateriaDTO notasMateria);
        public void Excluir(Guid id);
        public void Alterar(NotasMateriaDTO notasMateria);
    }
}
