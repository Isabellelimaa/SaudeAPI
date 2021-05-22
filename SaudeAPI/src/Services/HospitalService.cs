using Microsoft.EntityFrameworkCore;
using SaudeAPI.Context;
using SaudeAPI.Models;
using SaudeAPI.Models.Db;
using SaudeAPI.Services.Interfaces;
using SaudeAPI.src.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAPI.src.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly SaudeContext _context;
        private readonly ILogService _logService;

        public HospitalService(SaudeContext context, ILogService logService)
        {
            _context = context;
            _logService = logService;
        }

        public async Task<RespostaControlador> Get(int cdHsptal)
        {
            try
            {
                var hsptal = await _context.Hsptal
                    .Include(i => i.Endrco)
                    .Include(i => i.HsptalRefrncia)
                     .ThenInclude(t => t.Refrncia)
                    .ThenInclude(t => t.RefrnciaEnfrmdade)
                    .ThenInclude(t => t.Enfrmdade)
                    .Select(s => new
                    {
                        s.CdHsptal,
                        s.NmHsptal,
                        s.DcTlfone,
                        s.QtLeito,
                        Endrco = new
                        {
                            s.Endrco.NmPais,
                            s.Endrco.NmEstado,
                            s.Endrco.NmCidade,
                            s.Endrco.NmBairro,
                            s.Endrco.NmRua,
                            s.Endrco.NrNumero,
                            s.Endrco.DcComplmnto,
                            s.Endrco.DcCep,
                        },
                        Refrncia = s.HsptalRefrncia.Select(a => new
                        {
                            a.Refrncia.CdRefrncia,
                            a.Refrncia.NmRefrncia,
                            Enfrmdade = a.Refrncia.RefrnciaEnfrmdade.Select(b => new
                            {
                                b.Enfrmdade.CdEnfrmdade,
                                b.Enfrmdade.NmEnfrmdade
                            })
                        }),

                    })
                    .FirstOrDefaultAsync(f => f.CdHsptal == cdHsptal);

                return new RespostaControlador(true, "Listagem realizada com sucesso.", hsptal);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "GetHospital: " + ex.Message, DateTime.Now));
            }
        }

        public async Task<RespostaControlador> Search(int? cdEnfermidade = null)
        {
            try
            {

                var query = _context.Hsptal
                    .Include(i => i.Endrco)
                    .Include(i => i.HsptalRefrncia)
                    .ThenInclude(t => t.Refrncia)
                    .ThenInclude(t => t.RefrnciaEnfrmdade)
                    .ThenInclude(t => t.Enfrmdade)
                    .Select(s => new
                    {
                        s.CdHsptal,
                        s.NmHsptal,
                        s.DcTlfone,
                        s.QtLeito,
                        Endrco = new {
                            s.Endrco.NmPais,
                            s.Endrco.NmEstado,
                            s.Endrco.NmCidade,
                            s.Endrco.NmBairro,
                            s.Endrco.NmRua,
                            s.Endrco.NrNumero,
                            s.Endrco.DcComplmnto,
                            s.Endrco.DcCep,
                        },
                        Refrncia = s.HsptalRefrncia.Select(a => new
                        {
                            a.Refrncia.CdRefrncia,
                            a.Refrncia.NmRefrncia,
                            Enfrmdade = a.Refrncia.RefrnciaEnfrmdade.Select(b => new
                            {
                                b.Enfrmdade.CdEnfrmdade,
                                b.Enfrmdade.NmEnfrmdade
                            })
                        }),

                    })
                    .AsQueryable();

                if (cdEnfermidade != null)
                {
                    query.Where(w => w.Refrncia.Any(a => a.Enfrmdade.Any(a => a.CdEnfrmdade == cdEnfermidade)));
                }

                var hsptal = await query.ToListAsync();

                return new RespostaControlador(true, "Listagem realizada com sucesso.", hsptal);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "GetHospital: " + ex.Message, DateTime.Now));
            }
        }

        public async Task<RespostaControlador> ListReferencias()
        {
            try
            {
                var refrncias = await _context.Refrncia
                    .Select(s => new { s.CdRefrncia, s.NmRefrncia})
                    .ToListAsync();

                return new RespostaControlador(true, "Listagem realizada com sucesso.", refrncias);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "ListReferencias: " + ex.Message, DateTime.Now));
            }
        }

        public async Task<RespostaControlador> ListEnfermidades()
        {
            try
            {
                var enfrmdades = await _context.Enfrmdade
                    .Select(s => new { s.CdEnfrmdade, s.NmEnfrmdade })
                    .ToListAsync();

                return new RespostaControlador(true, "Listagem realizada com sucesso.", enfrmdades);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "ListEnfermidades: " + ex.Message, DateTime.Now));
            }
        }

        public async Task<RespostaControlador> ListExames()
        {
            try
            {
                var exames = await _context.Exame
                    .Select(s => new { s.CdExame, s.NmExame })
                    .ToListAsync();

                return new RespostaControlador(true, "Listagem realizada com sucesso.", exames);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "ListExames: " + ex.Message, DateTime.Now));
            }
        }
    }
}
