using Escola.Domain.DTO.V2;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;
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
            [FromQuery] string nome,
            int take = 5,
            int skip = 0
        )
        {
            if (!string.IsNullOrEmpty(nome))
                return Ok(_materiaServico.ObterPorNome(nome).Select(m => new MateriaDTO(m)));

            Paginacao paginacao = new(take, skip);
            int totalRegistros = _materiaServico.ObterTotal();
            Response.Headers.Add("X-Paginacao-TotalRegistros", totalRegistros.ToString());
            return Ok(_materiaServico.ObterTodos(paginacao).Select(m => new MateriaDTO(m)));
        }
        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public IActionResult ObterPorId(
            [FromRoute] Guid id
        )
        {
            return Ok(new MateriaDTO(_materiaServico.ObterPorId(id)));
        }
        [MapToApiVersion("2.0")]
        [HttpPost]
        public IActionResult Inserir(
            [FromBody] MateriaDTO materia
        )
        {
            Domain.DTO.V1.MateriaDTO materiaV1 = new()
            {
                Id = materia.Id,
                Nome = materia.Disciplina
            };
            _materiaServico.Inserir(materiaV1);
            return StatusCode(StatusCodes.Status201Created);
        }
        [MapToApiVersion("2.0")]
        [HttpPut("{id}")]
        public IActionResult Alterar(
            [FromRoute] Guid id,
            [FromBody] MateriaDTO materia
        )
        {
            materia.Id = id;
            Domain.DTO.V1.MateriaDTO materiaV1 = new()
            {
                Id = materia.Id,
                Nome = materia.Disciplina
            };
            _materiaServico.Alterar(materiaV1);
            return StatusCode(StatusCodes.Status201Created);
        }
        [MapToApiVersion("2.0")]
        [HttpDelete("{id}")]
        public IActionResult Excluir(
            [FromRoute] Guid id
        )
        {
            _materiaServico.Excluir(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
