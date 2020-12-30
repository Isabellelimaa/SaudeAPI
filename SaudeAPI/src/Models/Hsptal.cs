using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models
{
    public class Hsptal
    {
        [Key]
        public int CdHsptal {get; set;} 
        [StringLength(255)]
        public string NmHsptal {get; set;}
        public int CdEndrco {get; set;}
        [StringLength(15)]
        public string DcTlfone {get; set;}
        [MaxLength(10)]
        public int QtLeito {get;set;}
        public char IcAtivo {get; set;}
    }
}