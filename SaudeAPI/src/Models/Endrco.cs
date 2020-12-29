namespace SaudeAPI.Models
{
    public class Endrco
    {
        [Key]
        public int CdEndrco {get; set;}
        [StringLength(100)]
        public string NmPais {get; set;}
        [StringLength(100)]
        public string NmEstado {get; set;}
        [StringLength(150)]
        public string NmCidade {get; set;}
        [StringLength(100)]
        public string NmBairro {get; set;}
        [StringLength(200)]
        public string NmRua {get; set;}
        [MaxLength(10)]
        public int NrNumero {get; set;}
        [StringLength(200)]
        public string DcComplmnto {get; set;}
        [StringLength(10)]
        public string DcCep {get; set;}
    }
}