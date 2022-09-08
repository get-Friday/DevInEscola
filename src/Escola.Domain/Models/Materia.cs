using Escola.Domain.DTO.V1;

namespace Escola.Domain.Models
{
    public class Materia
    {
        public Guid Id { get; set; } = new Guid();
        public string Nome { get; set; }
        public Materia()
        {
        }
        public Materia(MateriaDTO materia)
        {
            Id = materia.Id;
            Nome = materia.Nome;
        }
        public void Update(MateriaDTO materia)
        {
            Id = materia.Id;
            Nome = materia.Nome;
        }
    }
}
