using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models
{
    public class SlctcaoEnfrmdade
    {
        [Key]
        public int CdSlctcaoEnfrmdade {get; set;}
        public int CdSlctcao {get; set;}
        public int CdEnfrmdade {get;set;}

        public Slctcao Slctcao {get; set;}
        public Enfrmdade Enfrmdade {get; set;}

    }
}