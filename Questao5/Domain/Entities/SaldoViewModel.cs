namespace Questao5.Domain.Entities
{
    public class SaldoViewModel
    {
        public string idContaCorrente { get; set; }

        public string numeroConta { get; set; }

        public string titularConta { get; set; }

        public DateTime Instante { get; set; }

        public double Saldo { get; set; }        
    }
}
