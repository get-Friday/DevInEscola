using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Models
{
    internal class Boletim
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AlunoId { get; set; }
    }
}
