namespace Questao5.Domain.Entities
{
    public class Q5Response
    {
        public bool Success { get; set; }

        public string? Message { get; set; }

        public object? Data { get; set; }

        public object? Error { get; set; }
    }
}
