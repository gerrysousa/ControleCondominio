using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ControleCondominio.Model
{
    public abstract class Pessoa
    {
        private int ID;
        private String nome;
        private String email;
        private String CPF;

        public Pessoa(String pnome, String pCPF, String pemail)
        {
            this.nome = pnome;
            this.CPF = pCPF;
            this.email = pemail;
        }
        public Pessoa()
        { }

        #region gets e sets
        public int IDs
        {
            get { return this.ID; }
            set { this.ID = value; }
        }

        public String Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public String Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public String Cpf
        {
            get { return this.CPF; }
            set { this.CPF = value; }
        }

        #endregion 

        #region métodos responsáveis pela persistência e manipulação dos objetos
       
        public abstract Boolean persistir;
        public abstract Boolean atualizar;
        public static Pessoa RecuperaObj(String ID)
        {
            Pessoa objPessoa = PessoaDao.recuperaObj(pID);
            return objPessoa;
        }

        public static IList RecuperaObjetos()
        {
            IList listPessoas = PessoaDao.recuperaObj();
            return listPessoas;
        }

        public static Boolean Excluir(String pID)
        {
            return PessoaDao.excluir(pID);
        }

    #endregion
    }
}
