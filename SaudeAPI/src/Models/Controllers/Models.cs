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

        public List<int> Referencia { get; set; }

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
}
