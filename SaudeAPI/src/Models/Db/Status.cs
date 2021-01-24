using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models.Db
{
    public class Status
    {
        [Key]
        public int CdStatus { get; set; }
        [StringLength(200)]
        public string NmStatus { get; set; }

        public List<Slctcao> Slctcao { get; set; }

    }
}