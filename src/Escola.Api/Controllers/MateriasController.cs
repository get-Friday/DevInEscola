using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriasController : ControllerBase
    {
        private readonly IMateriaServico _materiaServico;
        public MateriasController(IMateriaServico materiaServico)
        {
            _materiaServico = materiaServico;
        }
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_materiaServico.ObterTodos());
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(
            [FromRoute] Guid id   
        )
        {
            return Ok(_materiaServico.ObterPorId(id));
        }
        [HttpGet]
        public IActionResult ObterPorNome(
            [FromQuery] string nome
        )
        {
            return Ok(_materiaServico.ObterPorNome(nome));
        }
        [HttpPost]
        public IActionResult Inserir(
            [FromBody] MateriaDTO materia
        )
        {
            _materiaServico.Inserir(materia);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
