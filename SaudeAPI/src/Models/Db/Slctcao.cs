using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAPI.Models.Db
{
    public class Slctcao
    {
        public Slctcao(int cdHsptal, int cdPaciente, int cdStatus, string dcMotivo, int cdUsuarioRgst, DateTime dtRgst)
        {
            CdHsptal = cdHsptal;
            CdPaciente = cdPaciente;
            CdStatus = cdStatus;
            DcMotivo = dcMotivo;
            CdUsuarioRgst = cdUsuarioRgst;
            DtRgst = dtRgst;
        }

        [Key]
        public int CdSlctcao { get; set; }

        [ForeignKey("Hsptal")]
        public int CdHsptal { get; set; }

        [ForeignKey("Paciente")]
        public int CdPaciente { get; set; }

        [ForeignKey("Status")]
        public int CdStatus { get; set; }

        [StringLength(255)]
        public string DcMotivo { get; set; }

        [ForeignKey("Usuario")]
        public int CdUsuarioRgst { get; set; }

        [Required]
        public DateTime DtRgst { get; set; }

        public List<SlctcaoObs> SlctcaoObs { get; set; }
        public List<SlctcaoExame> SlctcaoExame { get; set; }
        public List<SlctcaoEnfrmdade> SlctcaoEnfrmdade { get; set; }

        public Hsptal Hsptal { get; set; }
        public Status Status { get; set; }
        public Paciente Paciente { get; set; }
        public Usuario Usuario { get; set; }

    }
}