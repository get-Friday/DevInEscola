using Escola.Domain.DTO.V1;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Escola.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MateriasController : ControllerBase
    {
        private readonly IMateriaServico _materiaServico;
        private readonly IMemoryCache _memoryCache;
        public MateriasController(IMateriaServico materiaServico, IMemoryCache memoryCache)
        {
            _materiaServico = materiaServico;
            _memoryCache = memoryCache;
        }
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult Obter(
            [FromQuery] string nome,
            int take = 5,
            int skip = 0
        )
        {
            if (!string.IsNullOrEmpty(nome))
                return Ok(_materiaServico.ObterPorNome(nome));

            Paginacao paginacao = new(take, skip);
            int totalRegistros = _materiaServico.ObterTotal();
            Response.Headers.Add("X-Paginacao-TotalRegistros", totalRegistros.ToString());
            return Ok(_materiaServico.ObterTodos(paginacao));
        }
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public IActionResult ObterPorId(
            [FromRoute] Guid id
        )
        {
            if (!_memoryCache.TryGetValue($"materia:{id}", out MateriaDTO materia))
            {
                materia = _materiaServico.ObterPorId(id);
                _memoryCache.Set($"materia:{id}", materia, new TimeSpan(0, 2, 0));
            }
            return Ok(materia);
        }
        [MapToApiVersion("1.0")]
        [HttpPost]
        public IActionResult Inserir(
            [FromBody] MateriaDTO materia
        )
        {
            _materiaServico.Inserir(materia);
            return StatusCode(StatusCodes.Status201Created);
        }
        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public IActionResult Excluir(
            [FromRoute] Guid id
        )
        {
            _memoryCache.Remove($"materia:{id}");
            _materiaServico.Excluir(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public IActionResult Alterar(
            [FromRoute] Guid id,
            [FromBody] MateriaDTO materia
        )
        {
            materia.Id = id;
            _materiaServico.Alterar(materia);
            _memoryCache.Set($"materia:{id}", materia, new TimeSpan(0, 2, 0));
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
