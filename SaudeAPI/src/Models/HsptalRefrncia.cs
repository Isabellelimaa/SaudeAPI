namespace SaudeAPI.Models
{
    public class HsptalRefrncia
    {
        [Key]
        public int CdHsptalRefrncia {get; set;}
        public int CdHsptal {get; set;}
        public int CdRefrncia {get; set;}
    }
}