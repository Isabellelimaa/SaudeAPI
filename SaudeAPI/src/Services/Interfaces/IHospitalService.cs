using SaudeAPI.Models;
using SaudeAPI.Models.Db;
using System.Threading.Tasks;

namespace SaudeAPI.src.Services
{
    public interface IHospitalService
    {
        Task<RespostaControlador> CreateHsptal(Hsptal hsptal);
    }
}