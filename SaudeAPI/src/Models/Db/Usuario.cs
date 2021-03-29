using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAPI.Models.Db
{
    public class Usuario
    {
        [Key]
        public int CdUsuario { get; set; }
        [StringLength(50)]
        public string DcLogin { get; set; }
        [StringLength(255)]
        public string DcSenha { get; set; }
        [StringLength(150)]
        public string DcEmail { get; set; }
        public int CdHsptal { get; set; }
        [StringLength(255)]
        public string DcTokencel { get; set; }

        [ForeignKey("CdHsptal")]
        public Hsptal Hsptal { get; set; }
    }
}