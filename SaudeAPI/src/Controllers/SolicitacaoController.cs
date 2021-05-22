using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaudeAPI.src.Models.Controllers;
using SaudeAPI.src.Services;
using System;
using System.Threading.Tasks;

namespace SaudeAPI.src.Controllers
{
    [Authorize("Bearer")]
    [Route("solicitacao")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        private readonly ISolicitacaoService _solicitacaoService;

        public SolicitacaoController(ISolicitacaoService solicitacaoService)
        {
            _solicitacaoService = solicitacaoService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSolicitacao createSolicitacao)
        {
            try
            {
                var request = await _solicitacaoService.Create(createSolicitacao);
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{cdSlctcao}")]
        public async Task<ActionResult> Get(int cdSlctcao)
        {
            try
            {
                var request = await _solicitacaoService.Get(cdSlctcao);
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("recebidas")]
        public async Task<ActionResult> GetRecebidas(int cdHsptal)
        {
            try
            {
                var request = await _solicitacaoService.GetRecebidas(cdHsptal);
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("enviadas")]
        public async Task<ActionResult> GetEnviadas(int cdUsuario)
        {
            try
            {
                var request = await _solicitacaoService.GetEnviadas(cdUsuario);
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{cdSlctcao}/alterar-status")]
        public async Task<ActionResult> AlterarStatus(int cdSlctcao, [FromQuery] int cdStatus)
        {
            try
            {
                var request = await _solicitacaoService.AlterarStatus(cdSlctcao, cdStatus);
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("obs")]
        public async Task<ActionResult> CreateObs([FromBody] CreateSolicitacaoObs createSolicitacaoObs)
        {
            try
            {
                var request = await _solicitacaoService.CreateObs(createSolicitacaoObs);
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{cdSlctcao}/obs")]
        public async Task<ActionResult> ListObservacoes(int cdSlctcao)
        {
            try
            {
                var request = await _solicitacaoService.ListObservacoes(cdSlctcao);
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
