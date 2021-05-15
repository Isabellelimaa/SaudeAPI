using SaudeAPI.Context;
using SaudeAPI.Models;
using SaudeAPI.Models.Db;
using SaudeAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAPI.src.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly SaudeContext _context;
        private readonly ILogService _logService;

        public HospitalService(SaudeContext context, ILogService logService)
        {
            _context = context;
            _logService = logService;
        }

        public async Task<RespostaControlador> CreateHsptal(Hsptal hsptal)
        {
            try
            {
                //var newHsptal = new Hsptal();

                return new RespostaControlador(false, "Usuario ou senha inválido.");
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "Login: " + ex.Message, DateTime.Now));
            }
        }
    }
}
