using Escola.Domain.DTO.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Models
{
    public class NotasMateria
    {
        public Guid Id { get; set; } = new Guid();
        public Guid BoletimId { get; set; }
        public Guid MateriaId { get; set; }
        public int Nota { get; set; }

        public Boletim Boletim { get; set; }
        public Materia Materia { get; set; }
        public NotasMateria()
        {
        }
        public NotasMateria(NotasMateriaDTO notasMateria)
        {
            Id = notasMateria.Id;
            BoletimId = notasMateria.BoletimId;
            MateriaId = notasMateria.MateriaId;
            Nota = notasMateria.Nota;
        }
        public void Update(NotasMateriaDTO notasMateria)
        {
            Id = notasMateria.Id;
            BoletimId = notasMateria.BoletimId;
            MateriaId = notasMateria.MateriaId;
            Nota = notasMateria.Nota;
        }
    }
}
