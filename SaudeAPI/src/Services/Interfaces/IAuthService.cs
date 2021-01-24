using System.Threading.Tasks;
using SaudeAPI.Models;
using SaudeAPI.Models.Db;

namespace SaudeAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RespostaControlador> Login(Usuario usuario);
    }
}