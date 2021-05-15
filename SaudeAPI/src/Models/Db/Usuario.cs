using System.ComponentModel.DataAnnotations;

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
    }
}