using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleCondominio.Dao;
using System.Collections;

namespace ControleCondominio.Model
{
    class Morador:Pessoa
    {
        private Boolean isResponsavel;
        private Apartamento apartamento;
        private string telefone;

        #region gets e sets
        public Boolean IsResponsavel
        {
            get { return this.isResponsavel; }
            set { this.isResponsavel = value; }
        }

        public Apartamento Apartamento
        {
            get { return this.apartamento; }
            set { this.apartamento = value; }
        }

        public string Telefone
        {
            get { return this.telefone; }
            set { this.telefone = value; }
        }
        #endregion

        #region Construtores
        public Morador(String pnome, String pCPF, String pemail, bool pIsResponsavel)
            :base(pnome, pCPF,pemail){
                this.isResponsavel=pIsResponsavel;
            }
        public Morador()//contruttor padrao
        {
        }
        #endregion

        #region métodos responsáveis pela persistência e manipulação dos objetos
        
        public override Boolean Persistir()
        {
                        
            MoradorDAO objMoradorDAO = new MoradorDAO();
            if (objMoradorDAO.Persistir(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public override Boolean Atualizar()
        {
            MoradorDAO objMoradorDAO = new MoradorDAO();
            if (objMoradorDAO.Atualizar(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Morador RecuperaObj(int pID)
        {
            Morador objMorador = MoradorDAO.RecuperaObj(pID);
            return objMorador;
        }

        public static IList RecuperaObjetos()
        {
            IList ListMoradores = MoradorDAO.RecuperaObjetos();
            return ListMoradores;
        }
        #endregion

    }
}
