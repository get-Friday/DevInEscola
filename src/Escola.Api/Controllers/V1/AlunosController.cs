using Microsoft.AspNetCore.Mvc;
using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Microsoft.Extensions.Caching.Memory;
using Escola.Domain.Models;

namespace Escola.Api.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoServico _alunoServico;
        private readonly IMemoryCache _memoryCache;
        public AlunosController(IAlunoServico alunoServico, IMemoryCache memoryCache)
        {
            _alunoServico = alunoServico;
            _memoryCache = memoryCache;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(
            [FromRoute] Guid id
        )
        {
            if (!_memoryCache.TryGetValue($"aluno:{id}", out AlunoDTO aluno))
            {
                aluno = _alunoServico.ObterPorId(id);
                _memoryCache.Set($"aluno:{id}", aluno, new TimeSpan(0, 2, 0));
            }
            return Ok(aluno);
        }
        [HttpGet]
        public IActionResult ObterTodos(int take = 5, int skip = 0)
        {
            Paginacao paginacao = new(take, skip);
            int totalRegistros = _alunoServico.ObterTotal();
            Response.Headers.Add("X-Paginacao-TotalRegistros", totalRegistros.ToString());
            return Ok(_alunoServico.ObterTodos(paginacao));
        }
        [HttpPost]
        public IActionResult Inserir(AlunoDTO aluno)
        {
            _alunoServico.Inserir(aluno);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            _memoryCache.Remove($"aluno:{id}");
            _alunoServico.Excluir(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPut("{id}")]
        public IActionResult Alterar(
            [FromRoute] Guid id,
            [FromBody] AlunoDTO aluno
        )
        {
            aluno.Id = id;
            _alunoServico.Alterar(aluno);
            _memoryCache.Set($"aluno:{id}", aluno, new TimeSpan(0, 2, 0));
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet("{id}/boletins")]
        public IActionResult ObterBoletins(
            [FromRoute] Guid id
        )
        {
            return Ok(_alunoServico.ObterBoletins(id));
        }
        [HttpGet("{idAluno}/boletins/{idBoletim}/NotasMateria")]
        public IActionResult ObterNotasMateria(
            [FromRoute] Guid idAluno,
            [FromRoute] Guid idBoletim
        )
        {
            return Ok(_alunoServico.ObterNotasMateria(idAluno, idBoletim));
        }
    }
}