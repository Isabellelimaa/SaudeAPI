using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models.Db
{
    public class Exame
    {
        [Key]
        public int CdExame { get; set; }
        [StringLength(200)]
        public string NmExame { get; set; }

        public List<SlctcaoExame> SlctcaoExame { get; set; }
    }
}