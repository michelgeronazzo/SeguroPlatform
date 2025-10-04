using ContratacaoService.Core.Domain;
using ContratacaoService.Core.Ports;

namespace ContratacaoService.Infra
{
    public class InMemoryContratacaoRepository : IContratacaoRepository
    {
        private readonly List<Contratacao> _store = new();
        public Task<Contratacao> AddAsync(Contratacao c) { _store.Add(c); return Task.FromResult(c); }
        public Task<IEnumerable<Contratacao>> GetAllAsync() => Task.FromResult<IEnumerable<Contratacao>>(_store);
    }

}
