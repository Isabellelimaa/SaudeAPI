namespace SaudeAPI.Models
{
    public class Usuario
    {
        [Key]
        public int CdUsuario {get; set;}
        [StringLength(50)]
        public string DcLogin {get; set;} 
        [StringLength(255)]
        public string DcSenha {get; set;}
        [StringLength(150)]
        public string DcEmail {get; set;}
        [StringLength(255)]
        public string DcTokencel {get; set;} 
    }
}