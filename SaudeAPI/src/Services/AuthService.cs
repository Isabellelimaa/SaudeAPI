using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaudeAPI.Configurations;
using SaudeAPI.Context;
using SaudeAPI.Models;
using SaudeAPI.Models.Db;
using SaudeAPI.Services.Interfaces;

namespace SaudeAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly SaudeContext _context;
        private readonly CryptoConfigurations _crypto;
        private readonly ITokenService _tokenService;
        private readonly ILogService _logService;

        public AuthService(SaudeContext context, CryptoConfigurations crypto,
            ITokenService tokenService, ILogService logService)
        {
            _context = context;
            _crypto = crypto;
            _tokenService = tokenService;
            _logService = logService;
        }

        public async Task<RespostaControlador> Login(Usuario userLogin)
        {
            try
            {
                var user = new Usuario();
                bool validCredentials = false;

                if (string.IsNullOrEmpty(userLogin.DcLogin) || string.IsNullOrEmpty(userLogin.DcSenha))
                    return new RespostaControlador(false, "Usuario ou senha inválido.");

                user = await _context.Usuario
                    .FirstOrDefaultAsync(f => f.DcLogin.ToLower() == userLogin.DcLogin.ToLower());

                if (user == null)
                    return new RespostaControlador(false, "Usuário não encontrado.");

                validCredentials = _crypto.VerifyPassword(userLogin.DcSenha, user.DcSenha);

                if (validCredentials)
                {
                    return _tokenService.ReturnToken(null, user);
                }
                else
                {
                    return new RespostaControlador(false, "Usuario ou senha inválido.");
                }
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "Login: " + ex.Message, DateTime.Now));
            }
        }
    }
}