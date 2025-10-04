using ContratacaoService.Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ContratacaoService.Api.Controllers
{
    [ApiController]
    [Route("api/contratacoes")]
    public class ContratacaoController : ControllerBase
    {
        private readonly IContratacaoService _service;
        public ContratacaoController(IContratacaoService service) => _service = service;

        [HttpPost("{propostaId:guid}")]
        public async Task<IActionResult> Contratar(Guid propostaId)
        {
            var c = await _service.ContratarAsync(propostaId);

            return c == null ? BadRequest(new { message = "Proposta não encontrada." }) : CreatedAtAction(nameof(Obter), new { id = c.Id }, c);
        }

        [HttpGet]
        public async Task<IActionResult> Listar() => Ok(await _service.ListarAsync());

        [HttpGet("{id:guid}")]
        public IActionResult Obter(Guid id) => Ok(); // simplificação: não usado no exemplo
    }

}
