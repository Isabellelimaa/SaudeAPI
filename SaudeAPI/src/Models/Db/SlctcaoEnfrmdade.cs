using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAPI.Models.Db
{
    public class SlctcaoEnfrmdade
    {
        public SlctcaoEnfrmdade(int cdSlctcao, int cdEnfrmdade)
        {
            CdSlctcao = cdSlctcao;
            CdEnfrmdade = cdEnfrmdade;
        }

        [Key]
        public int CdSlctcaoEnfrmdade { get; set; }
        [ForeignKey("Slctcao")]
        public int CdSlctcao { get; set; }
        [ForeignKey("Enfrmdade")]
        public int CdEnfrmdade { get; set; }

        public Slctcao Slctcao { get; set; }
        public Enfrmdade Enfrmdade { get; set; }

    }
}