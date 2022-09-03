using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.DTO
{
    public class NotasMateriaDTO
    {
        public Guid Id { get; set; } = new Guid();
        public Guid BoletimId { get; set; }
        public Guid MateriaId { get; set; }
        public int Nota { get; set; }
        public NotasMateriaDTO()
        {
        }
        public NotasMateriaDTO(NotasMateria notasMateria)
        {
            Id = notasMateria.Id;
            BoletimId = notasMateria.BoletimId;
            MateriaId = notasMateria.MateriaId;
            Nota = notasMateria.Nota;
        }
    }
}
