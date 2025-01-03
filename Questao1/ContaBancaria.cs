using System;
using System.Globalization;

namespace Questao1
{
    public class ContaBancaria
    {
        private int numero;
        private string titular;
        private double depositoInicial;
        private double saldo;

        private readonly double taxa = 3.5;

        public ContaBancaria(int numero, string titular)
        {
            this.numero = numero;
            this.titular = titular;
            this.saldo = 0;
        }

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            this.numero = numero;
            this.titular = titular;
            this.depositoInicial = depositoInicial;
            this.saldo = depositoInicial;
        }

        internal void Deposito(double quantia)
        {
            this.saldo = this.saldo + Math.Abs(quantia);
        }

        internal void Saque(double quantia)
        {
            this.saldo = (this.saldo - Math.Abs(quantia)) - this.taxa;
        }

        public string toString()
        {
            return string.Format("Conta {0}, Titular: {1}, Saldo: {2:0.00}", this.numero, this.titular, this.saldo);
        }
    }
}
