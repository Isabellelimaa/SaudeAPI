using System;

namespace SaudeAPI.Models
{
    public class RespostaControlador
    {
        public Object Resultado { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }

        public RespostaControlador() { }
        public RespostaControlador(bool sucesso, string mensagem)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
        }
        public RespostaControlador(bool sucesso, string mensagem, Object resultado)
        {
            this.Resultado = resultado;
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
        }
    }
}