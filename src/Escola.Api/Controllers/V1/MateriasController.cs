﻿using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MateriasController : ControllerBase
    {
        private readonly IMateriaServico _materiaServico;
        public MateriasController(IMateriaServico materiaServico)
        {
            _materiaServico = materiaServico;
        }
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult Obter(
            [FromQuery] string nome
        )
        {
            if (!string.IsNullOrEmpty(nome))
                return Ok(_materiaServico.ObterPorNome(nome));
            return Ok(_materiaServico.ObterTodos());
        }
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public IActionResult ObterPorId(
            [FromRoute] Guid id
        )
        {
            return Ok(_materiaServico.ObterPorId(id));
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
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}