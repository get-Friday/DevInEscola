using Escola.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
