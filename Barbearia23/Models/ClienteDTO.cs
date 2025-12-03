namespace Barbearia23.Models
{
    public class ClienteDTO
    {
       // public string ClienteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public bool Ativo {get; set;}
    }
}
