using System.Threading.Tasks;
using SaudeAPI.Models;
using SaudeAPI.Models.Db;
using SaudeAPI.src.Models.Controller;

namespace SaudeAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RespostaControlador> Login(Usuario usuario);

        Task<RespostaControlador> Create(CreateUsuario createUsuario);
    }
}