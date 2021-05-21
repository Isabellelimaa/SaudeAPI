using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAPI.Models.Db
{
    public class Usuario
    {
        public Usuario()
        {
        }

        public Usuario(string dcLogin, string dcSenha, string dcEmail)
        {
            DcLogin = dcLogin;
            DcSenha = dcSenha;
            DcEmail = dcEmail;
        }

        [Key]
        public int CdUsuario { get; set; }
        [StringLength(50)]
        public string DcLogin { get; set; }
        [StringLength(255)]
        public string DcSenha { get; set; }
        [StringLength(150)]
        public string DcEmail { get; set; }
        [StringLength(255)]
        public string DcTokencel { get; set; }

        public Hsptal Hsptal { get; set; }

        public List<Slctcao> Slctcao { get; set; }
        public List<SlctcaoObs> SlctcaoObs { get; set; }
        public List<Paciente> Paciente { get; set; }
        public List<Log> Log { get; set; }

    }
}