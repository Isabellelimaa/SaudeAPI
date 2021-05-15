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

        [HttpPost]
        public async Task<ActionResult<Object>> Login([FromBody] Usuario usuario)
        {
            try
            {
                var request = await _authService.Login(usuario);
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