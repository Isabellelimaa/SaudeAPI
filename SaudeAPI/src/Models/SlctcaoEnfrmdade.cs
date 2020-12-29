namespace SaudeAPI.Models
{
    public class SlctcaoEnfrmdade
    {
        [Key]
        //Comentario
        public int CdSlctcaoEnfrmdade {get; set;}
        public int CdSlctcao {get; set;}
        public int CdEnfrmdade {get;set;}
    }
}