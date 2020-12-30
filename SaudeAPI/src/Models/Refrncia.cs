using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models
{
    public class Refrncia
    {
        [Key]
        public int CdRefrncia {get; set;}
        [StringLength(150)]
        public string NmRefrncia {get; set;}
    }
}