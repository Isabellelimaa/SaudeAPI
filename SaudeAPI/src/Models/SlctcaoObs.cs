using System;
using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models
{
    public class SlctcaoObs
    {
        [Key]
        public int CdSlctcaoObs {get; set;}
        public int CdSlctcao {get; set;}
        [StringLength(255)]
        public string DcObs {get; set;}
        public int CdUsuario {get; set;}
        [Required]
        public DateTime DtRgst {get; set;}

        public Slctcao Slctcao {get; set;}

    }
}