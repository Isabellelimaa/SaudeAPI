using System;
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
    }
}