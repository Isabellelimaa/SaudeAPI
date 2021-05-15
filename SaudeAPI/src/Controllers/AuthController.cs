using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SaudeAPI.Models.Db;
using SaudeAPI.Services.Interfaces;
using SaudeAPI.src.Models.Controller;

namespace SaudeAPI.Controllers
{
    //[Authorize("Bearer")]
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
        public async Task<ActionResult> Login([FromBody] LoginUser loginUser)
        {
            try
            {
                var request = await _authService.Login(loginUser.dcLogin, loginUser.dcSenha);
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
        public async Task<ActionResult> CreateUsuario(string dcLogin, string dcSenha, string dcEmail)
        {
            try
            {
                var request = await _authService.CreateUsuario(dcLogin, dcSenha, dcEmail);
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Object>> Create([FromBody] CreateUsuario createUsuario)
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