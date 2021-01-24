using System;
using System.Security.Claims;
using SaudeAPI.Models;

namespace SaudeAPI.Services.Interfaces
{
    public interface ITokenService
    {
        RespostaControlador ReturnToken(ClaimsIdentity identity, Object user);
    }
}