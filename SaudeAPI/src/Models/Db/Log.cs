using System;
using System.ComponentModel.DataAnnotations;

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

        public int? CdUsuario { get; set; }

        [StringLength(200)]
        public string DcLog { get; set; }

        public DateTime DtLog { get; set; } = DateTime.Now;
    }
}