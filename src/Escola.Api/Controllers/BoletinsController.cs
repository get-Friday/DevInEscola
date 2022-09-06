using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletinsController : Controller
    {
        private readonly IBoletimServico _boletimServico;
        public BoletinsController(IBoletimServico boletimServico)
        {
            _boletimServico = boletimServico;
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(
            [FromRoute] Guid id    
        )
        {
            _boletimServico.ObterPorId(id);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public IActionResult Inserir(
            [FromBody] BoletimDTO boletim
        )
        {
            _boletimServico.Inserir(boletim);
            return StatusCode(StatusCodes.Status201Created);
        }
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
        [HttpDelete("{id}")]
        public IActionResult Excluir(
            [FromRoute] Guid id    
        )
        {
            _boletimServico.Excluir(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
