using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SaudeAPI.Services.Interfaces;
using SaudeAPI.src.Models.Controllers;

namespace SaudeAPI.Controllers
{
    [Authorize("Bearer")]
    [Route("usuario")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] string dcLogin, string dcSenha)
        {
            try
            {
                var request = await _authService.Login(dcLogin, dcSenha);
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> CreateUsuario([FromBody] CreateUsuario createUsuario)
        {
            try
            {
                var request = await _authService.Create(createUsuario);
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}