using Escola.Domain.DTO.V1;

namespace Escola.Domain.Models
{
    public class Boletim
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AlunoId { get; set; }

        public Aluno Aluno { get; set; }
        public IList<NotasMateria> NotasMateria { get; set; }
        public Boletim()
        {
        }
        public Boletim(BoletimDTO boletim)
        {
            Id = boletim.Id;
            AlunoId = boletim.AlunoId;
        }
        public void Update(BoletimDTO boletim)
        {
            Id = boletim.Id;
            AlunoId = boletim.AlunoId;
        }
    }
}
