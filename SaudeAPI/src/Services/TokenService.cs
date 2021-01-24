using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SaudeAPI.Configs;
using SaudeAPI.Models;
using SaudeAPI.Services.Interfaces;

namespace SaudeAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly SigningConfigurations _signingConfigurations;
        private readonly RecoverConfigurations _recoverConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly ILogService _logService;

        public TokenService(SigningConfigurations signingConfigurations,
            RecoverConfigurations recoverConfigurations, TokenConfigurations tokenConfigurations,
            ILogService logService)
        {
            _signingConfigurations = signingConfigurations;
            _recoverConfigurations = recoverConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _logService = logService;
        }

        public RespostaControlador ReturnToken(ClaimsIdentity identity, Object user)
        {
            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromMinutes(240);
            TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            TimeSpan finalExpiration =
                TimeSpan.FromSeconds(_tokenConfigurations.FinalExpiration);

            var token = handler.WriteToken(securityToken);

            var result = new
            {
                user = user,
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "Ok"
            };

            return new RespostaControlador(true, "Usuário autenticado com sucesso.", result);
        }
    }
}