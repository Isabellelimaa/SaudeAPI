using System;
using System.Threading.Tasks;
using SaudeAPI.Context;
using SaudeAPI.Models;
using SaudeAPI.Models.Db;
using SaudeAPI.Services.Interfaces;

namespace SaudeAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly SaudeContext _context;
        private readonly ILogService _logService;

        public AuthService(SaudeContext context, ILogService logService)
        {
            _context = context;
            _logService = logService;
        }

        public async Task<RespostaControlador> Login(Usuario usuario)
        {
            try
            {
                return new RespostaControlador(true, "Senha gerada com sucesso!", null);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "Login: " + ex.Message, DateTime.Now));
            }
        }
    }
}