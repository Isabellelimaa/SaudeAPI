using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAPI.Models.Db
{
    public class Paciente
    {
        public Paciente(string nmPaciente, string dcCpf, string dcRg, int cdUsuarioRgst, DateTime dtRgst)
        {
            NmPaciente = nmPaciente;
            DcCpf = dcCpf;
            DcRg = dcRg;
            CdUsuarioRgst = cdUsuarioRgst;
            DtRgst = dtRgst;
        }

        [Key]
        public int CdPaciente { get; set; }

        [StringLength(150)]
        public string NmPaciente { get; set; }

        [StringLength(15)]
        public string DcCpf { get; set; }

        [StringLength(10)]
        public string DcRg { get; set; }

        [ForeignKey("Usuario")]
        public int CdUsuarioRgst { get; set; }

        [Required]
        public DateTime DtRgst { get; set; }

        public List<Slctcao> Slctcao { get; set; }

        public Usuario Usuario { get; set; }
    }
}