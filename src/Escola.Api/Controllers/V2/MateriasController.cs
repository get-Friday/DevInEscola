using Escola.Domain.DTO;
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
    }
}
