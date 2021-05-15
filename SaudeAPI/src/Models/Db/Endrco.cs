using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaudeAPI.Models.Db
{
    public class Endrco
    {
        public Endrco(string nmEstado, string nmCidade, string nmBairro, string nmRua, int nrNumero, string dcComplmnto, string dcCep)
        {
            NmPais = "Brasil";
            NmEstado = nmEstado;
            NmCidade = nmCidade;
            NmBairro = nmBairro;
            NmRua = nmRua;
            NrNumero = nrNumero;
            DcComplmnto = dcComplmnto;
            DcCep = dcCep;
        }

        [Key]
        public int CdEndrco { get; set; }
        [StringLength(100)]
        public string NmPais { get; set; }
        [StringLength(100)]
        public string NmEstado { get; set; }
        [StringLength(150)]
        public string NmCidade { get; set; }
        [StringLength(100)]
        public string NmBairro { get; set; }
        [StringLength(200)]
        public string NmRua { get; set; }
        [MaxLength(10)]
        public int NrNumero { get; set; }
        [StringLength(200)]
        public string DcComplmnto { get; set; }
        [StringLength(10)]
        public string DcCep { get; set; }

        public List<Hsptal> Hsptal { get; set; }
    }
}