namespace SaudeAPI.Models
{
    public class Exame
    {
        [Key]
        public int CdExame {get; set;}
        [StringLength(200)]
        public string NmExame {get; set;}
    }
}