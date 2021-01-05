using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models
{
    public class Enfrmdade
    {
        [Key]
        public int CdEnfrmdade {get; set;}
        [StringLength(200)]
        public string NmEnfrmdade {get; set;}

        public List<SlctcaoEnfrmdade> SlctcaoEnfrmdade {get; set;}
        public List<RefrnciaEnfrmdade> RefrnciaEnfrmdade {get; set;}
    }
}