using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models
{
    public class Slctcao
    {
        [Key]
        public int CdSlctcao {get; set;}
        public int CdPaciente {get; set;}
        public int CdStatus {get; set;}
        [StringLength(255)]
        public string DcMotivo {get; set;}
        public int CdUsuarioRgst {get; set;}
        [Required]
        public DateTime DtRgst {get; set;}

        public List<SlctcaoObs> SlctcaoObs {get; set;}
        public List<SlctcaoExame> SlctcaoExame {get; set;}
        public List<SlctcaoEnfrmdade> SlctcaoEnfrmdade {get; set;}

        public Status Status {get; set;}
        public Paciente Paciente {get; set;}

    }
}