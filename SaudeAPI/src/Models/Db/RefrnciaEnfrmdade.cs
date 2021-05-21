using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAPI.Models.Db
{
    public class RefrnciaEnfrmdade
    {
        [Key]
        public int CdRefrnciaEnfrmdade { get; set; }
        [ForeignKey("Refrncia")]
        public int CdRefrncia { get; set; }
        [ForeignKey("Enfrmdade")]
        public int CdEnfrmdade { get; set; }

        public Refrncia Refrncia { get; set; }
        public Enfrmdade Enfrmdade { get; set; }
    }
}