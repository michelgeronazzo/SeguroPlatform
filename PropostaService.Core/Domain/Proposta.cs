using Shared.Enums;

namespace PropostaService.Core.Domain
{
    public class Proposta
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Proponente { get; set; } = null!;
        public decimal Valor { get; set; }
        public PropostaStatus Status { get; set; } = PropostaStatus.EmAnalise;
        public string NameStatus { get; set; } = "Em Análise";
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }

}
