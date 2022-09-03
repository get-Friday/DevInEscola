using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasMateriaController : Controller
    {
        private readonly INotasMateriaServico _notasMateriaServico;
        public NotasMateriaController(INotasMateriaServico notasMateriaServico)
        {
            _notasMateriaServico = notasMateriaServico;
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(
            [FromRoute] Guid id
        )
        {
            return Ok(_notasMateriaServico.ObterPorId(id));
        }
        [HttpPost]
        public IActionResult Inserir(
            [FromBody] NotasMateriaDTO notasMateria
        )
        {
            _notasMateriaServico.Inserir(notasMateria);
            return StatusCode(StatusCodes.Status201Created);
        }
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
