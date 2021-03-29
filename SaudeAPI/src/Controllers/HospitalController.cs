using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaudeAPI.Models.Db;
using SaudeAPI.Services.Interfaces;
using SaudeAPI.src.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public async Task<ActionResult<Object>> CreateHospital([FromBody] Hsptal hsptal)
        {
            try
            {
                var request = await _hospitalService.CreateHsptal(hsptal);
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
