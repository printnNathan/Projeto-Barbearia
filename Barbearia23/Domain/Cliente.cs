namespace Barbearia23.Domain
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
