namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        public string idmovimento {  get; set; }

        public int idcontacorrente { get; set; }

        public string datamovimento { get; set; }

        public string tipomovimento { get; set; }

        public double valor { get; set; }
    }
}
