using Microsoft.AspNetCore.Mvc;
using PropostaService.Core.UseCases;
using Shared.Dto;

namespace PropostaService.Api.Controllers
{
    [ApiController]
    [Route("api/propostas")]
    public class PropostaController : ControllerBase
    {
        private readonly IPropostaService _service;
        public PropostaController(IPropostaService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarPropostaDto dto)
        {
            var p = await _service.CriarAsync(dto.Proponente, dto.Valor);
            return CreatedAtAction(nameof(Obter), new { id = p.Id }, p);
        }

        [HttpGet]
        public async Task<IActionResult> Listar() => Ok(await _service.ListarAsync());

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            var p = (await _service.ListarAsync()).FirstOrDefault(x => x.Id == id);
            return p == null ? NotFound() : Ok(p);
        }

        [HttpPatch("{id:guid}/status")]
        public async Task<IActionResult> AlterarStatus(Guid id, [FromBody] AlterarStatusDto dto)
        {
            var ok = await _service.AlterarStatusAsync(id, dto.Status);
            return ok ? NoContent() : NotFound();
        }
    }

}
