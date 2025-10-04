using ContratacaoService.Core.Domain;
using ContratacaoService.Core.Ports;

namespace ContratacaoService.Core.UseCases
{
    public interface IContratacaoService
    {
        Task<Contratacao?> ContratarAsync(Guid propostaId);
        Task<IEnumerable<Contratacao>> ListarAsync();
    }
    public class ContratacaoService : IContratacaoService
    {
        private readonly IContratacaoRepository _repo;
        private readonly IPropostaRemotePort _propostaRemote;
        public ContratacaoService(IContratacaoRepository repo, IPropostaRemotePort propostaRemote)
        {
            _repo = repo; _propostaRemote = propostaRemote;
        }

        public async Task<Contratacao?> ContratarAsync(Guid propostaId)
        {
            var proposta = await _propostaRemote.ObterPropostaAsync(propostaId);

            if (proposta == null) return null;

            var c = new Contratacao { PropostaId = propostaId, Status = proposta.Status, NameStatus = (proposta.Status == Shared.Enums.PropostaStatus.EmAnalise ? "Em Analise" : proposta.Status == Shared.Enums.PropostaStatus.Rejeitada ? "Rejeitado" : "Aprovado") };

            return await _repo.AddAsync(c);
        }

        public Task<IEnumerable<Contratacao>> ListarAsync() => _repo.GetAllAsync();
    }

}
