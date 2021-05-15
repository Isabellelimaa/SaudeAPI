using System.Threading.Tasks;
using SaudeAPI.Models;
using SaudeAPI.Models.Db;
using SaudeAPI.src.Models.Controllers;

namespace SaudeAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RespostaControlador> Login(string dcLogin, string dcSenha);

        Task<RespostaControlador> Create(CreateUsuario createUsuario);
    }
}