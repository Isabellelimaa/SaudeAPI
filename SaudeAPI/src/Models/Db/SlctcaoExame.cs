using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAPI.Models.Db
{
    public class SlctcaoExame
    {
        public SlctcaoExame(int cdSlctcao, int cdExame)
        {
            CdSlctcao = cdSlctcao;
            CdExame = cdExame;
        }

        [Key]
        public int CdSlctcaoExame { get; set; }
        [ForeignKey("Slctcao")]
        public int CdSlctcao { get; set; }
        [ForeignKey("Exame")]
        public int CdExame { get; set; }

        public Slctcao Slctcao { get; set; }
        public Exame Exame { get; set; }
    }
}