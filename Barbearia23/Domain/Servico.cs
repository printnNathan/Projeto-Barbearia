namespace Barbearia23.Domain
{
    public class Servico
    {
        public int ServicoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Duracao { get; set; }
        public bool Ativo { get; set; } 
    }
}
