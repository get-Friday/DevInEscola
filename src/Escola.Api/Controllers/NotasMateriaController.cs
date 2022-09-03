using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasMateriaController : Controller
    {
        private readonly INotasMateriaServico _notasMateriaServico;
        public NotasMateriaController(INotasMateriaServico notasMateriaServico)
        {
            _notasMateriaServico = notasMateriaServico;
        }
    }
}
