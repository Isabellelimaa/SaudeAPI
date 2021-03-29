using System.Threading.Tasks;
using SaudeAPI.Models;
using SaudeAPI.Models.Db;

namespace SaudeAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RespostaControlador> Login(string dcLogin, string dcSenha);
        Task<RespostaControlador> CreateUsuario(string dcLogin, string dcSenha, string dcEmail);
    }
}