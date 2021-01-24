using System;
using System.Threading.Tasks;
using SaudeAPI.Context;
using SaudeAPI.Models;
using SaudeAPI.Models.Db;
using SaudeAPI.Services.Interfaces;

namespace SaudeAPI.Services
{
    public class LogService : ILogService
    {
        private readonly SaudeContext _context;

        public LogService(SaudeContext context)
        {
            _context = context;
        }

        public async Task<RespostaControlador> GerarLog(Log exceptionLog)
        {
            try
            {
                await _context.Log.AddAsync(exceptionLog);
                await _context.SaveChangesAsync();
                return new RespostaControlador()
                {
                    Sucesso = false,
                    Mensagem = "Não foi possível concluir a solicitação."
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}