using PropostaService.Core.Domain;

namespace PropostaService.Core.Ports
{
    public interface IPropostaRepository
    {
        Task<Proposta> AddAsync(Proposta proposta);
        Task<IEnumerable<Proposta>> GetAllAsync();
        Task<Proposta?> GetByIdAsync(Guid id);
        Task UpdateAsync(Proposta proposta);
    }

}
