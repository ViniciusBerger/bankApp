using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace bankapp
{
    internal class ContaCorrente : IComparable<ContaCorrente>
    {
        private string account;
        private int agency;
        private double balance;
        Client titular;
        public int totaldeContasCriadas = 0;
        

        public string Account { get { return account; } set { account = value; }}
        public int Agency { get { return agency; } set { agency = value; }}
        
        public double Balance { get { return balance; } set { balance = value; } }

        public Client Titular { get { return titular; } set { titular = value; }}

        public ContaCorrente(int Agency, double Balance, string name, string cpf, string profession)
        {
            this.Account = Guid.NewGuid().ToString().Substring(0, 9);
            this.Agency = Agency;
            this.Balance = Balance;
            titular = new Client(name, cpf, profession);
            totaldeContasCriadas += 1;
        }        

        public override string ToString()
        {
            return $"Name: {titular.Name + Environment.NewLine} SIN: {titular.Cpf + Environment.NewLine} Account: {Account + Environment.NewLine} Agency: {Agency + Environment.NewLine} Balance: {Balance + Environment.NewLine}";
        }

        public int CompareTo(ContaCorrente other)
        {
            if (other == null) 
            { return 1; }
            else
            {
                return this.Agency.CompareTo(other.Agency);
            }
        }
    }
}
