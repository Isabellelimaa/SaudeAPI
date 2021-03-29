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

        public async Task<RespostaControlador> Login(string dcLogin, string dcSenha)
        {
            try
            {
                var user = new Usuario();
                bool validCredentials = false;

                if (string.IsNullOrEmpty(dcLogin) || string.IsNullOrEmpty(dcSenha))
                    return new RespostaControlador(false, "Usuario ou senha inválido.");

                user = await _context.Usuario
                    .FirstOrDefaultAsync(f => f.DcLogin.ToLower() == dcLogin.ToLower());

                if (user == null)
                    return new RespostaControlador(false, "Usuário não encontrado.");

                validCredentials = _crypto.VerifyPassword(dcSenha, user.DcSenha);

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
        public async Task<RespostaControlador> CreateUsuario(string dcLogin, string dcSenha, string dcEmail)
        {
            try
            {
                var user = new Usuario();

                if (string.IsNullOrEmpty(dcLogin) || string.IsNullOrEmpty(dcSenha) || string.IsNullOrEmpty(dcEmail))
                    return new RespostaControlador(false, "Usuario, senha ou email não informados.");

                user = await _context.Usuario
                    .FirstOrDefaultAsync(f => f.DcLogin.ToLower() == dcLogin.ToLower());

                if (user != null)
                    return new RespostaControlador(false, "Usuário já cadastrado.");

                var newSenha = _crypto.ChangePassword(dcSenha);

                var newUsuario = new Usuario(){
                    DcLogin= dcLogin, 
                    DcSenha = newSenha, 
                    DcEmail = dcEmail
                };

                await _context.AddAsync<Usuario>(newUsuario);
                await _context.SaveChangesAsync();

                    return new RespostaControlador(true, "Usuário criado com sucesso.", newUsuario);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "CreateUsuario: " + ex.Message, DateTime.Now));
            }
        }
    }
}