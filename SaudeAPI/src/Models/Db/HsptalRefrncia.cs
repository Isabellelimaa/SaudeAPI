using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAPI.Models.Db
{
    public class HsptalRefrncia
    {
        public HsptalRefrncia(int cdHsptal, int cdRefrncia)
        {
            CdHsptal = cdHsptal;
            CdRefrncia = cdRefrncia;
        }

        [Key]
        public int CdHsptalRefrncia { get; set; }

        [ForeignKey("Hsptal")]
        public int CdHsptal { get; set; }

        [ForeignKey("Refrncia")]
        public int CdRefrncia { get; set; }

        public Hsptal Hsptal { get; set; }
        public Refrncia Refrncia { get; set; }
    }
}