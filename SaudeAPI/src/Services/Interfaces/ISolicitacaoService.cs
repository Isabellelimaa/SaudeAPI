using SaudeAPI.Models;
using SaudeAPI.src.Models.Controllers;
using System.Threading.Tasks;

namespace SaudeAPI.src.Services
{
    public interface ISolicitacaoService
    {
        Task<RespostaControlador> Create(CreateSolicitacao createSolicitacao);

        Task<RespostaControlador> Get(int cdSlctcao);

        Task<RespostaControlador> GetRecebidas(int cdHsptal);

        Task<RespostaControlador> GetEnviadas(int cdUsuario);

        Task<RespostaControlador> ListObservacoes(int cdSlctcao);

        Task<RespostaControlador> AlterarStatus(int cdSlctcao, int cdStatus);

        Task<RespostaControlador> CreateObs(CreateSolicitacaoObs createSolicitacaoObs);
    }
}