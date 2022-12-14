using Escola.Domain.Models;

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
