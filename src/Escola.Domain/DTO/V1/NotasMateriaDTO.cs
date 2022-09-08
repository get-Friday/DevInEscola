using Escola.Domain.Models;

namespace Escola.Domain.DTO.V1
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
