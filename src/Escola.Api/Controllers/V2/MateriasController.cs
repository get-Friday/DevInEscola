using Escola.Domain.DTO.V2;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MateriasController : ControllerBase
    {
        private readonly IMateriaServico _materiaServico;
        public MateriasController(IMateriaServico materiaServico)
        {
            _materiaServico = materiaServico;
        }
        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult Obter(
            [FromQuery] string nome
        )
        {
            if (!string.IsNullOrEmpty(nome))
                return Ok(_materiaServico.ObterPorNome(nome).Select(m => new MateriaDTO(m)));
            return Ok(_materiaServico.ObterTodos().Select(m => new MateriaDTO(m)));
        }
        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public IActionResult ObterPorId(
            [FromRoute] Guid id
        )
        {
            return Ok(new MateriaDTO(_materiaServico.ObterPorId(id)));
        }
    }
}
