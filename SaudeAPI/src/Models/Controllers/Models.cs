using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAPI.src.Models.Controllers
{
    public class LoginUser
    {
        public string dcLogin { get; set; }

        public string dcSenha { get; set; }
    }

    public class CreateUsuario
    {
        public string DcLogin { get; set; }

        public string DcSenha { get; set; }

        public string DcEmail { get; set; }

        public Hospital Hospital { get; set; }

        public Endereco Endereco { get; set; }

    }

    public class Hospital
    {
        public string NmHsptal { get; set; }

        public string DcTlfone { get; set; }

        public List<int> CdReferencia { get; set; }

        public int QtLeito { get; set; }
    }

    public class Endereco
    {
        public string NmEstado { get; set; }

        public string NmCidade { get; set; }

        public string NmBairro { get; set; }

        public string NmRua { get; set; }

        public int NrNumero { get; set; }

        public string DcComplmnto { get; set; }

        public string DcCep { get; set; }
    }

    public class CreateSolicitacao
    {
        public int CdUsuario { get; set; }
        public int CdHsptal { get; set; }


        public PacienteSlctcao Paciente { get; set; }

        public string DcMotivo { get; set; }

        public List<int> CdExame { get; set; }

        public List<int> CdEnfrmdade { get; set; }
    }

    public class PacienteSlctcao
    {
        public string NmPaciente { get; set; }

        public string DcCpf { get; set; }

        public string DcRg { get; set; }
    }

    public class CreateSolicitacaoObs
    {
        public int CdSlctcao { get; set; }

        public string DcObs { get; set; }

        public int CdUsuarioRgst { get; set; }
    }
}
