using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankapp
{
    internal class Client
    {
        string name;
        string cpf;
        string profession;

        public string Name { get {return name;} set { name = value; } }
        public string Cpf { get {return cpf;} set { cpf = value; } }
        public string Profession { get {return profession;} set { profession = value; } }
    
        public Client(string Name, string cpf, string Profession) 
        {
            this.Name = Name;
            this.cpf = cpf;
            this.profession = Profession;
        }
    }
}
