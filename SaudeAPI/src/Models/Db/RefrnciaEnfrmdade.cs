using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models.Db
{
    public class RefrnciaEnfrmdade
    {
        [Key]
        public int CdRefrnciaEnfrmdade { get; set; }
        public int CdRefrncia { get; set; }
        public int CdEnfrmdade { get; set; }

        public Refrncia Refrncia { get; set; }
        public Enfrmdade Enfrmdade { get; set; }
    }
}