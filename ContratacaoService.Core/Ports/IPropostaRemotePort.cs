using PropostaService.Core.Domain;

namespace ContratacaoService.Core.Ports
{
    public interface IPropostaRemotePort
    {
        Task<Proposta?> ObterPropostaAsync(Guid id);
    }

}
