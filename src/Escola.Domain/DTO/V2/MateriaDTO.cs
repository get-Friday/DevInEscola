using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.DTO.V2
{
    public class MateriaDTO
    {
        public Guid Id { get; set; }
        public string Disciplina { get; set; }
        public MateriaDTO()
        {
        }
        public MateriaDTO(Materia materia)
        {
            Id = materia.Id;
            Disciplina = materia.Nome;
        }
    }
}
