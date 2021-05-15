using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAPI.Models.Db
{
    public class Hsptal
    {
        public Hsptal(string nmHsptal, int cdUsuario, int cdEndrco, string dcTlfone, int qtLeito)
        {
            NmHsptal = nmHsptal;
            CdUsuario = cdUsuario;
            CdEndrco = cdEndrco;
            DcTlfone = dcTlfone;
            QtLeito = qtLeito;
            IcAtivo = 'S';
        }

        [Key]
        public int CdHsptal { get; set; }
        [StringLength(255)]
        public string NmHsptal { get; set; }
        [ForeignKey("Usuario")]
        public int CdUsuario { get; set; }
        [ForeignKey("Endrco")]
        public int CdEndrco { get; set; }
        [StringLength(15)]
        public string DcTlfone { get; set; }
        [MaxLength(10)]
        public int QtLeito { get; set; }
        public char IcAtivo { get; set; }

        public List<HsptalRefrncia> HsptalRefrncia { get; set; }
        public Usuario Usuario { get; set; }
        public Endrco Endrco { get; set; }
    }
}