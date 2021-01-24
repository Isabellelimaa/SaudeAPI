using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models.Db
{
    public class SlctcaoExame
    {
        [Key]
        public int CdSlctcaoExame { get; set; }
        public int CdSlctcao { get; set; }
        public int CdExame { get; set; }

        public Slctcao Slctcao { get; set; }
        public Exame Exame { get; set; }
    }
}