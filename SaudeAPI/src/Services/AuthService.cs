using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaudeAPI.Configurations;
using SaudeAPI.Context;
using SaudeAPI.Models;
using SaudeAPI.Models.Db;
using SaudeAPI.Services.Interfaces;
using SaudeAPI.src.Models.Controllers;

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

        public async Task<RespostaControlador> Create(CreateUsuario createUsuario)
        {
            try
            {
                var user = new Usuario();

                if (string.IsNullOrEmpty(createUsuario.DcLogin) || string.IsNullOrEmpty(createUsuario.DcSenha) || string.IsNullOrEmpty(createUsuario.DcEmail))
                    return new RespostaControlador(false, "Usuario, senha ou email não informados.");

                user = await _context.Usuario
                               .FirstOrDefaultAsync(f => f.DcLogin.ToLower() == createUsuario.DcLogin.ToLower());

                if (user != null)
                    return new RespostaControlador(false, "Usuário já cadastrado.");

                var newSenha = _crypto.ChangePassword(createUsuario.DcSenha);

                var newUsuario = new Usuario(createUsuario.DcLogin, createUsuario.DcSenha, createUsuario.DcSenha);
                
                await _context.AddAsync<Usuario>(user);

                var newEndrco = new Endrco(
                    createUsuario.Endereco.NmEstado,
                    createUsuario.Endereco.NmCidade,
                    createUsuario.Endereco.NmBairro,
                    createUsuario.Endereco.NmRua,
                    createUsuario.Endereco.NrNumero,
                    createUsuario.Endereco.DcComplmnto,
                    createUsuario.Endereco.DcCep);

                await _context.AddAsync<Endrco>(newEndrco);
                await _context.SaveChangesAsync();

                var newHsptal = new Hsptal(
                    createUsuario.Hospital.NmHsptal,
                    newUsuario.CdUsuario,
                    newEndrco.CdEndrco,
                    createUsuario.Hospital.DcTlfone,
                    createUsuario.Hospital.QtLeito);

                await _context.AddAsync<Hsptal>(newHsptal);
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