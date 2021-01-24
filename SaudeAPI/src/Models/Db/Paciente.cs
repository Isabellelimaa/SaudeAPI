using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models.Db
{
    public class Paciente
    {
        [Key]
        public int CdPaciente { get; set; }
        [StringLength(150)]
        public string NmPaciente { get; set; }
        [StringLength(15)]
        public string DcCpf { get; set; }
        [StringLength(10)]
        public string DcRg { get; set; }
        public int CdUsuarioRgst { get; set; }
        [Required]
        public DateTime DtRgst { get; set; }

        public List<Slctcao> Slctcao { get; set; }
    }
}