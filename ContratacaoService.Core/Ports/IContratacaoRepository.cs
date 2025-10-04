using ContratacaoService.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Core.Ports
{
    public interface IContratacaoRepository
    {
        Task<Contratacao> AddAsync(Contratacao c);
        Task<IEnumerable<Contratacao>> GetAllAsync();
    }
}
