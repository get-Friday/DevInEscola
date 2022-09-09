using AutoMapper;
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
        private readonly IMapper _mapper;
        public MateriasController(IMateriaServico materiaServico, IMapper mapper)
        {
            _materiaServico = materiaServico;
            _mapper = mapper;
        }
        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult Obter(
            [FromQuery] string nome,
            int pagina = 1
        )
        {
            if (!string.IsNullOrEmpty(nome))
                return Ok(_mapper.Map<List<Domain.DTO.V2.MateriaDTO>>(_materiaServico.ObterPorNome(nome)));

            Paginacao paginacao = new(pagina);
            int totalRegistros = _materiaServico.ObterTotal();
            Response.Headers.Add("X-Paginacao-TotalRegistros", totalRegistros.ToString());
            return Ok(_mapper.Map<List<Domain.DTO.V2.MateriaDTO>>(_materiaServico.ObterTodos(paginacao)));
        }
        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public IActionResult ObterPorId(
            [FromRoute] Guid id
        )
        {
            return Ok(_mapper.Map<Domain.DTO.V2.MateriaDTO>(_materiaServico.ObterPorId(id)));
        }
        [MapToApiVersion("2.0")]
        [HttpPost]
        public IActionResult Inserir(
            [FromBody] Domain.DTO.V2.MateriaDTO materia
        )
        {
            _materiaServico.Inserir(_mapper.Map<Domain.DTO.V1.MateriaDTO>(materia));
            return StatusCode(StatusCodes.Status201Created);
        }
        [MapToApiVersion("2.0")]
        [HttpPut("{id}")]
        public IActionResult Alterar(
            [FromRoute] Guid id,
            [FromBody] Domain.DTO.V2.MateriaDTO materia
        )
        {
            materia.Id = id;
            _materiaServico.Alterar(_mapper.Map<Domain.DTO.V1.MateriaDTO>(materia));
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
