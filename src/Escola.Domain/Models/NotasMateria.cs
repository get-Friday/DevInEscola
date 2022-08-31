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
    }
}
