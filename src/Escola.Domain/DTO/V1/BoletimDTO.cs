using Escola.Domain.Models;

namespace Escola.Domain.DTO.V1
{
    public class BoletimDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AlunoId { get; set; }
        public BoletimDTO()
        {
        }
        public BoletimDTO(Boletim boletim)
        {
            Id = boletim.Id;
            AlunoId = boletim.AlunoId;
        }
    }
}
