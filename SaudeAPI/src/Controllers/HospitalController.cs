using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaudeAPI.src.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SaudeAPI.src.Controllers
{
    [Authorize("Bearer")]
    [Route("hospital")]
    [ApiController]
    public class HospitalController : ControllerBase
    {

        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet("{cdHsptal}")]
        public async Task<ActionResult<Object>> Get(int cdHsptal)
        {
            try
            {
                var request = await _hospitalService.Get(cdHsptal);
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<Object>> Search(int? cdEnfermidade)
        {
            try
            {
                var request = await _hospitalService.Search(cdEnfermidade);
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("list-referencia")]
        public async Task<ActionResult<Object>> ListReferencias()
        {
            try
            {
                var request = await _hospitalService.ListReferencias();
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("list-enfermidades")]
        public async Task<ActionResult<Object>> ListEnfermidades()
        {
            try
            {
                var request = await _hospitalService.ListEnfermidades();
                if (!request.Sucesso)
                    return BadRequest(request.Mensagem);
                return Ok(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("list-exames")]
        public async Task<ActionResult<Object>> ListExames()
        {
            try
            {
                var request = await _hospitalService.ListExames();
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
