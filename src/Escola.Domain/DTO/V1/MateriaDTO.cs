using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.DTO.V1
{
    public class MateriaDTO
    {
        public MateriaDTO()
        {
        }
        public MateriaDTO(Materia materia)
        {
            Id = materia.Id;
            Nome = materia.Nome;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
