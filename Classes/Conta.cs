using System;

namespace Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            this.Saldo -= valorSaque;
            if (valorSaque < this.Saldo + this.Credito)
            {
                Console.WriteLine("O Valor atual disponível na conta do " + this.Nome + "é de R$ " + this.Saldo);
                return true;
            }
            else
            {
                Console.WriteLine("Valor de Saque é superior ao valor disponível + o valor de crédito");
                return false;
            }

        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta do(a) " + this.Nome + "é de R$ " + this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo Conta " + this.TipoConta + "|";
            retorno += "Nome " + this.Nome + "|";
            retorno += "Saldo " + this.Saldo + "|";
            retorno += "Crédito " + this.Credito;

            return retorno;

        }

    }
}