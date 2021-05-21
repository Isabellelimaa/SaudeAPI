using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeAPI.Models.Db
{
    public class Log
    {
        public Log() { }
        public Log(int? CdUsuario, string descricao, DateTime data)
        {
            this.CdUsuario = CdUsuario;
            this.DcLog = descricao;
            this.DtLog = data;
        }

        [Key]
        public int CdLog { get; set; }

        [ForeignKey("Usuario")]
        public int? CdUsuario { get; set; }

        [StringLength(200)]
        public string DcLog { get; set; }

        public DateTime DtLog { get; set; } = DateTime.Now;

        public Usuario Usuario { get; set; }

    }
}