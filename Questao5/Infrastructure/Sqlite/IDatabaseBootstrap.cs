using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Sqlite
{
    public interface IDatabaseBootstrap
    {
        void Setup();

        (bool, bool) ContaCorrenteExistsActive(string idContaCorrente);

        string InsertMovimento(string idContaCorrente, string tipoMovimento, double valor);

        SaldoViewModel GetSaldo(string idContaCorrente);
    }
}