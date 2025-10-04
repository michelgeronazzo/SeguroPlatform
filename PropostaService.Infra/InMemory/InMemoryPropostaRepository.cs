using PropostaService.Core.Domain;
using PropostaService.Core.Ports;
using System.Collections.Concurrent;

namespace PropostaService.Infra.InMemory
{
    public class InMemoryPropostaRepository : IPropostaRepository
    {
        private readonly ConcurrentDictionary<Guid, Proposta> _store = new();

        public Task<Proposta> AddAsync(Proposta proposta)
        {
            // garante thread-safety e evita sobrescrever por acidente
            _store[proposta.Id] = proposta;
            return Task.FromResult(proposta);
        }

        public Task<IEnumerable<Proposta>> GetAllAsync()
        {
            var all = _store.Values.OrderBy(p => p.CreatedAt).AsEnumerable();
            return Task.FromResult<IEnumerable<Proposta>>(all);
        }

        public Task<Proposta?> GetByIdAsync(Guid id)
        {
            _store.TryGetValue(id, out var proposta);
            return Task.FromResult(proposta);
        }

        public Task UpdateAsync(Proposta proposta)
        {
            // Atualiza somente se existir; mantém comportamento idempotente
            if (_store.ContainsKey(proposta.Id))
            {
                _store[proposta.Id] = proposta;
            }
            return Task.CompletedTask;
        }
    }

}
