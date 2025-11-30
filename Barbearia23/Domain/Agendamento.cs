namespace Barbearia23.Domain
{
    public class Agendamento
    {
        public int AgendamentoId { get; set; }
        public int ClienteId { get; set; }
        public int BarbeiroId { get; set; }
        public int ServicoId { get; set; }  
        public DateTime DataHora { get; set; }
        public string Status { get; set; }
        public bool Ativo { get; set; }

    }
}
