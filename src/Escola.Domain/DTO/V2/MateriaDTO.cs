namespace Escola.Domain.DTO.V2
{
    public class MateriaDTO
    {
        public Guid Id { get; set; }
        public string Disciplina { get; set; }
        public MateriaDTO()
        {
        }
        public MateriaDTO(V1.MateriaDTO materia)
        {
            Id = materia.Id;
            Disciplina = materia.Nome;
        }
    }
}
