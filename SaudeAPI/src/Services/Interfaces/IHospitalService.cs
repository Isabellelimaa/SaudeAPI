using SaudeAPI.Models;
using System.Threading.Tasks;

namespace SaudeAPI.src.Services.Interfaces
{
    public interface IHospitalService
    {
        Task<RespostaControlador> Get(int cdHsptal);

        Task<RespostaControlador> Search(int? cdEnfermidade = null);

        Task<RespostaControlador> ListReferencias();

        Task<RespostaControlador> ListEnfermidades();

        Task<RespostaControlador> ListExames();

    }
}
