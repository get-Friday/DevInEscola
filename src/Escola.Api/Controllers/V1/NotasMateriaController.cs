using Escola.Domain.DTO.V1;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class NotasMateriaController : Controller
    {
        private readonly INotasMateriaServico _notasMateriaServico;
        public NotasMateriaController(INotasMateriaServico notasMateriaServico)
        {
            _notasMateriaServico = notasMateriaServico;
        }
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public IActionResult ObterPorId(
            [FromRoute] Guid id
        )
        {
            return Ok(_notasMateriaServico.ObterPorId(id));
        }
        [MapToApiVersion("1.0")]
        [HttpPost]
        public IActionResult Inserir(
            [FromBody] NotasMateriaDTO notasMateria
        )
        {
            _notasMateriaServico.Inserir(notasMateria);
            return StatusCode(StatusCodes.Status201Created);
        }
        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public IActionResult Alterar(
            [FromRoute] Guid id,
            [FromBody] NotasMateriaDTO notasMateria
        )
        {
            notasMateria.Id = id;
            _notasMateriaServico.Alterar(notasMateria);
            return StatusCode(StatusCodes.Status201Created);
        }
        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public IActionResult Excluir(
            [FromRoute] Guid id
        )
        {
            _notasMateriaServico.Excluir(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
