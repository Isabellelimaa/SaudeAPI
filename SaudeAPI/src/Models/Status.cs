namespace SaudeAPI.Models
{
    public class Status
    {
        [Key]
        public int CdStatus {get; set;}
        [StringLength(200)]
        public string NmStatus {get; set;}
    }
}