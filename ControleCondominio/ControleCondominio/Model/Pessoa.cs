using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCondominio.Model
{
    public abstract class Pessoa
    {
        private int ID;
        private string nome;
        private string email;
        private string CPF;

        public Pessoa(string pnome, string pCPF, string pemail)
        {
            this.nome = pnome;
            this.CPF = pCPF;
            this.email = pemail;
        }
        public Pessoa()
        { }

        public int ID
        {
            get { return this.ID;}
            set { this.ID = value; }
        }

        public string
    }
}
