using System.Threading.Tasks;
using SaudeAPI.Models;
using SaudeAPI.Models.Db;

namespace SaudeAPI.Services.Interfaces
{
    public interface ILogService
    {
        Task<RespostaControlador> GerarLog(Log exceptionLog);
    }
}