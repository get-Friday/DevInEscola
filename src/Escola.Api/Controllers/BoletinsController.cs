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
    }
}
