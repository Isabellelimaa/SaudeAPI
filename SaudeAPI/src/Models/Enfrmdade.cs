namespace SaudeAPI.Models
{
    public class Enfrmdade
    {
        [Key]
        public int CdEnfrmdade {get; set;}
        [StringLength(200)]
        public string NmEnfrmdade {get; set;}
    }
}