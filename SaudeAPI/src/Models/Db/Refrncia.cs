using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models.Db
{
    public class Refrncia
    {
        [Key]
        public int CdRefrncia { get; set; }

        [StringLength(150)]
        public string NmRefrncia { get; set; }

        public List<HsptalRefrncia> HsptalRefrncia { get; set; }
        public List<RefrnciaEnfrmdade> RefrnciaEnfrmdade { get; set; }
    }
}