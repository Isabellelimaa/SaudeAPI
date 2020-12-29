namespace SaudeAPI.Models
{
    public class SlctcaoExame
    {
        [Key]
        public int CdSlctcaoExame {get; set;}
        public int CdSlctcao {get; set;}
        public int CdExame {get; set;}
    }
}