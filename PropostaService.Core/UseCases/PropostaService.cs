using PropostaService.Core.Domain;
using PropostaService.Core.Ports;
using Shared.Enums;

namespace PropostaService.Core.UseCases
{
    public interface IPropostaService
    {
        Task<Proposta> CriarAsync(string proponente, decimal valor);
        Task<IEnumerable<Proposta>> ListarAsync();
        Task<bool> AlterarStatusAsync(Guid id, PropostaStatus status);
    }

    public class PropostaService : IPropostaService
    {
        private readonly IPropostaRepository _repo;
        public PropostaService(IPropostaRepository repo) => _repo = repo;
        public Task<Proposta> CriarAsync(string proponente, decimal valor)
        {
            var p = new Proposta { Proponente = proponente, Valor = valor };
            return _repo.AddAsync(p);
        }
        public Task<IEnumerable<Proposta>> ListarAsync() => _repo.GetAllAsync();
        public async Task<bool> AlterarStatusAsync(Guid id, PropostaStatus status)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return false;
            p.Status = status;
            p.NameStatus = (status == Shared.Enums.PropostaStatus.EmAnalise ? "Em Análise" : status == Shared.Enums.PropostaStatus.Rejeitada ? "Rejeitado" : "Aprovado");
            await _repo.UpdateAsync(p);
            return true;
        }
    }

}
