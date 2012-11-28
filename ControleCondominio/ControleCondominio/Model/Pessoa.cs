using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ControleCondominio.Dao;

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
       
        public int Id
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
       
        public abstract Boolean Persistir();
        
        public abstract Boolean Atualizar();
        
        public static Pessoa RecuperaObj(String ID)
        {
            Pessoa objPessoa = PessoaDAO.RecuperaObj(pID);
            return objPessoa;
        }

        public static IList RecuperaObjetos()
        {
            IList listPessoas = PessoaDAO.RecuperaObj();
            return listPessoas;
        }

        public static IList RecuperaObjetosPorTipo(object ptipo)
        {
            IList listPessoas = PessoaDAO.RecuperaObjetosPorTipo();
            return listPessoas;
        }

        public static IList RecuperaObjetosPorApartamento(int pID)
        {
            IList listPessoas = PessoaDAO.RecuperaObjetosPorApartamento(pID);
            return listPessoas;
        }
        
        public static Boolean Excluir(String pID)
        {
            return PessoaDAO.Rxcluir(pID);
        }

    #endregion
    }
}
