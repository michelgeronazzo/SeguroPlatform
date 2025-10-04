using Shared.Enums;

namespace ContratacaoService.Core.Domain
{
    public class Contratacao
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid PropostaId { get; set; }
        public DateTime DataContratacao { get; set; } = DateTime.UtcNow;
        public PropostaStatus Status { get; set; }
        public string NameStatus { get; set; }
    }

}
