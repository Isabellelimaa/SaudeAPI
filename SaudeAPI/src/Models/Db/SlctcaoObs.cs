using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAPI.Models.Db
{
    public class SlctcaoObs
    {
        public SlctcaoObs(int cdSlctcao, string dcObs, int cdUsuarioRgst, DateTime dtRgst)
        {
            CdSlctcao = cdSlctcao;
            DcObs = dcObs;
            CdUsuarioRgst = cdUsuarioRgst;
            DtRgst = dtRgst;
        }

        [Key]
        public int CdSlctcaoObs { get; set; }
        [ForeignKey("Slctcao")]
        public int CdSlctcao { get; set; }
        [StringLength(255)]
        public string DcObs { get; set; }
        [ForeignKey("Usuario")]
        public int CdUsuarioRgst { get; }
        [Required]
        public DateTime DtRgst { get; set; }

        public Slctcao Slctcao { get; set; }
        public Usuario Usuario { get; set; }

    }
}