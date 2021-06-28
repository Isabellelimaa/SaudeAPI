using Microsoft.EntityFrameworkCore;
using SaudeAPI.Context;
using SaudeAPI.Models;
using SaudeAPI.Models.Db;
using SaudeAPI.Services.Interfaces;
using SaudeAPI.src.Models.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAPI.src.Services
{
    public class SolicitacaoService : ISolicitacaoService
    {
        private readonly SaudeContext _context;
        private readonly ILogService _logService;

        public SolicitacaoService(SaudeContext context, ILogService logService)
        {
            _context = context;
            _logService = logService;
        }

        public async Task<RespostaControlador> Create(CreateSolicitacao createSolicitacao)
        {
            try
            {
                var newPaciente = new Paciente(createSolicitacao.Paciente.NmPaciente, createSolicitacao.Paciente.DcCpf, createSolicitacao.Paciente.DcRg, createSolicitacao.CdUsuario, DateTime.Now);
                await _context.Paciente.AddAsync(newPaciente);
                await _context.SaveChangesAsync();

                var newSlctcao = new Slctcao(createSolicitacao.CdHsptal, newPaciente.CdPaciente,1, createSolicitacao.DcMotivo, createSolicitacao.CdUsuario, DateTime.Now);
                await _context.Slctcao.AddAsync(newSlctcao);
                await _context.SaveChangesAsync();

                foreach (var cdEnfrmdade in createSolicitacao.CdEnfrmdade)
                {
                    var newSlctcaoEnfrmdade = new SlctcaoEnfrmdade(newSlctcao.CdSlctcao, cdEnfrmdade);
                    await _context.SlctcaoEnfrmdade.AddAsync(newSlctcaoEnfrmdade);
                }

                foreach (var cdExame in createSolicitacao.CdExame)
                {
                    var newSlctcaoExame = new SlctcaoExame(newSlctcao.CdSlctcao, cdExame);
                    await _context.SlctcaoExame.AddAsync(newSlctcaoExame);
                }

                await _context.SaveChangesAsync();

                return new RespostaControlador(true, "Solicitação criado com sucesso.", newSlctcao);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "CreateSolicitacao: " + ex.Message, DateTime.Now));
            }
        }

        public async Task<RespostaControlador> Get(int cdSlctcao)
        {
            try
            {
                var slctcao = await _context.Slctcao
                    .Include(i => i.Hsptal)
                    .ThenInclude(t => t.Endrco)
                    .Include(i => i.Hsptal.HsptalRefrncia)
                    .ThenInclude(t => t.Refrncia)
                    .Include(i => i.Paciente)
                    .Include(i => i.SlctcaoEnfrmdade)
                    .Include(i => i.SlctcaoExame)
                    .ThenInclude(t => t.Exame)
                    .Include(i => i.Status)
                    .Select(s => new
                    {
                        s.CdSlctcao,
                        s.DcMotivo,
                        DtRgst = s.DtRgst.ToString("dd/MM/yyyy"),
                        SlctcaoExame = s.SlctcaoExame.Select(a => new
                        {
                            a.Exame.CdExame,
                            a.Exame.NmExame,
                        }),
                        Status = new
                        {
                            s.Status.CdStatus,
                            s.Status.NmStatus,
                        },
                        Hsptal = new
                        {
                            s.Hsptal.NmHsptal,
                            s.Hsptal.DcTlfone,
                            s.Hsptal.QtLeito,
                            Endrco = new
                            {
                                s.Hsptal.Endrco.NmPais,
                                s.Hsptal.Endrco.NmEstado,
                                s.Hsptal.Endrco.NmCidade,
                                s.Hsptal.Endrco.NmBairro,
                                s.Hsptal.Endrco.NmRua,
                                s.Hsptal.Endrco.NrNumero,
                                s.Hsptal.Endrco.DcComplmnto,
                                s.Hsptal.Endrco.DcCep,
                            },
                            Refrncia = s.Hsptal.HsptalRefrncia.Select(a => new
                            {
                                a.Refrncia.CdRefrncia,
                                a.Refrncia.NmRefrncia,
                            }),
                        },
                        Paciente = new
                        {
                            s.Paciente.CdPaciente,
                            s.Paciente.NmPaciente,
                            s.Paciente.DcCpf,
                            s.Paciente.DcRg,
                        },
                    })
                    .FirstOrDefaultAsync(f => f.CdSlctcao == cdSlctcao);

                return new RespostaControlador(true, "Listagem realizada com sucesso.", slctcao);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "GetSolicitacao: " + ex.Message, DateTime.Now));
            }
        }

        public async Task<RespostaControlador> GetRecebidas(int cdHsptal)
        {
            try
            {
                var slctcoes = await _context.Slctcao
                    .Where(w => w.CdHsptal == cdHsptal)
                    .Include(i => i.Paciente)
                    .Include(i => i.Status)
                    .Include(i => i.SlctcaoObs)
                    .Select(s => new
                    {
                        s.CdSlctcao,
                        s.DcMotivo,
                        DataRegistro = s.DtRgst.ToString("dd/MM/yyyy"),
                        Status = new
                        {
                            s.Status.CdStatus,
                            s.Status.NmStatus,
                        },
                        Paciente = new
                        {
                            s.Paciente.CdPaciente,
                            s.Paciente.NmPaciente,
                            s.Paciente.DcCpf,
                            s.Paciente.DcRg,
                        },
                        SlctcaoObs = s.SlctcaoObs.OrderByDescending(o => o.DtRgst).Select(a => new
                        {
                            a.CdSlctcaoObs,
                            a.DcObs,
                            DtRgst = a.DtRgst.ToString("dd/MM/yyyy"),
                        }).First(),
                    })
                    .ToListAsync();

                return new RespostaControlador(true, "Listagem realizada com sucesso.", slctcoes);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "GetSolicitacao: " + ex.Message, DateTime.Now));
            }
        }

        public async Task<RespostaControlador> GetEnviadas(int cdUsuario)
        {
            try
            {
                var slctcoes = await _context.Slctcao
                    .Where(w => w.CdUsuarioRgst == cdUsuario)
                    .Include(i => i.Hsptal)
                    .Include(i => i.Paciente)
                    .Include(i => i.Status)
                    .Include(i => i.SlctcaoObs)
                    .Select(s => new
                    {
                        s.CdSlctcao,
                        s.DcMotivo,
                        DataRegistro = s.DtRgst.ToString("dd/MM/yyyy"),
                        Status = new
                        {
                            s.Status.CdStatus,
                            s.Status.NmStatus,
                        },
                        Paciente = new
                        {
                            s.Paciente.CdPaciente,
                            s.Paciente.NmPaciente,
                            s.Paciente.DcCpf,
                            s.Paciente.DcRg,
                        },
                        Hsptal = new
                        {
                            s.Hsptal.NmHsptal,
                            s.Hsptal.DcTlfone,
                            s.Hsptal.QtLeito,
                        },
                        SlctcaoObs = s.SlctcaoObs.OrderByDescending(o => o.DtRgst).Select(a => new
                        {
                            a.CdSlctcaoObs,
                            a.DcObs,
                            DtRgst = a.DtRgst.ToString("dd/MM/yyyy"),
                        }).First(),
                    })
                    .ToListAsync();

                return new RespostaControlador(true, "Listagem realizada com sucesso.", slctcoes);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "GetSolicitacao: " + ex.Message, DateTime.Now));
            }
        }

        public async Task<RespostaControlador> ListObservacoes(int cdSlctcao)
        {
            try
            {
                var slctcaoObs = await _context.SlctcaoObs
                    .Where(w => w.CdSlctcao == cdSlctcao)
                    .OrderBy(o => o.DtRgst)
                    .Select(s => new
                    {
                        s.CdSlctcaoObs,
                        s.DcObs,
                        s.CdUsuarioRgst,
                        DtRgst = s.DtRgst.ToString("dd/MM/yyyy"),
                    })
                    .ToListAsync();

                return new RespostaControlador(true, "Listagem realizada com sucesso.", slctcaoObs);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "ListExames: " + ex.Message, DateTime.Now));
            }
        }

        public async Task<RespostaControlador> AlterarStatus(int cdSlctcao, int cdStatus)
        {
            try
            {
                var slctcao = _context.Slctcao
                    .Where(w => w.CdSlctcao == cdSlctcao)
                    .FirstOrDefault();

                if(slctcao == null)
                    return new RespostaControlador(false, "Solicitação não encontrada.");

                slctcao.CdStatus = cdStatus;

                _context.Slctcao.Update(slctcao);
                await _context.SaveChangesAsync();

                return new RespostaControlador(true, "Listagem realizada com sucesso.", slctcao);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "AlterarStatus: " + ex.Message, DateTime.Now));
            }
        }

        public async Task<RespostaControlador> CreateObs(CreateSolicitacaoObs createSolicitacaoObs)
        {
            try
            {
                var slctcao = _context.Slctcao
                    .Where(w => w.CdSlctcao == createSolicitacaoObs.CdSlctcao)
                    .FirstOrDefault();

                if (slctcao == null)
                    return new RespostaControlador(false, "Solicitação não encontrada.");

                var newSlctcaoObs = new SlctcaoObs(createSolicitacaoObs.CdSlctcao, createSolicitacaoObs.DcObs, createSolicitacaoObs.CdUsuarioRgst, DateTime.Now);
                
                await _context.SlctcaoObs.AddAsync(newSlctcaoObs);
                await _context.SaveChangesAsync();

                return new RespostaControlador(true, "Observação inserida com sucesso.", slctcao);
            }
            catch (Exception ex)
            {
                return await _logService.GerarLog(new Log(0, "AlterarStatus: " + ex.Message, DateTime.Now));
            }
        }
    }
}
