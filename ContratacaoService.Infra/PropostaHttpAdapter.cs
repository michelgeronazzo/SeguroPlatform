using ContratacaoService.Core.Ports;
using PropostaService.Core.Domain;
using System.Net.Http.Json;

namespace ContratacaoService.Infra
{
    public class PropostaHttpAdapter : IPropostaRemotePort
    {
        private readonly HttpClient _http;
        public PropostaHttpAdapter(HttpClient http) { _http = http; }
        public async Task<Proposta?> ObterPropostaAsync(Guid id)
        {
            var resp = await _http.GetAsync($"/api/propostas/{id}");
            if (!resp.IsSuccessStatusCode) return null;
            return await resp.Content.ReadFromJsonAsync<Proposta>();
        }
    }

}
