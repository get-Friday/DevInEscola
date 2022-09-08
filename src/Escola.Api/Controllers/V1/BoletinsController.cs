using Escola.Domain.DTO.V1;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BoletinsController : Controller
    {
        private readonly IBoletimServico _boletimServico;
        public BoletinsController(IBoletimServico boletimServico)
        {
            _boletimServico = boletimServico;
        }
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public IActionResult ObterPorId(
            [FromRoute] Guid id
        )
        {
            return Ok(_boletimServico.ObterPorId(id));
        }
        [MapToApiVersion("1.0")]
        [HttpPost]
        public IActionResult Inserir(
            [FromBody] BoletimDTO boletim
        )
        {
            _boletimServico.Inserir(boletim);
            return StatusCode(StatusCodes.Status201Created);
        }
        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public IActionResult Alterar(
            [FromRoute] Guid id,
            [FromBody] BoletimDTO boletim
        )
        {
            boletim.Id = id;
            _boletimServico.Alterar(boletim);
            return StatusCode(StatusCodes.Status201Created);
        }
        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public IActionResult Excluir(
            [FromRoute] Guid id
        )
        {
            _boletimServico.Excluir(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [MapToApiVersion("1.0")]
        [HttpGet("{id}/boletins")]
        public IActionResult ObterBoletins(
            [FromRoute] Guid id
        )
        {
            return Ok(_boletimServico.ObterBoletins(id));
        }
        [MapToApiVersion("1.0")]
        [HttpGet("{idAluno}/boletins/{idBoletim}/NotasMateria")]
        public IActionResult ObterNotasMateria(
            [FromRoute] Guid idAluno,
            [FromRoute] Guid idBoletim
        )
        {
            return Ok(_boletimServico.ObterNotasMateria(idAluno, idBoletim));
        }
    }
}
