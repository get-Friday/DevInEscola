using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Models
{
    internal class Materia
    {
        public Guid Id { get; set; } = new Guid();
        public string Nome { get; set; }
    }
}
