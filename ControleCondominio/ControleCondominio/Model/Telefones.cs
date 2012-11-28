using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ControleCondominio.Model
{
    class Telefones
    {
        private int IDpessoa;
        private int numero;

        #region gets e sets
        public int IDPessoa
        {
            get { return this.IDpessoa; }
            set { this.IDpessoa = value; }
        }

        public int Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }
        #endregion

        #region Construtores
        public Telefones(int pIDpessoa, int pnumero){
            this.IDpessoa=pIDpessoa;
            this.numero=pnumero;
        }
        public Telefones()//contruttor padrao
        {
        }
        #endregion

        #region métodos responsáveis pela persistência e manipulação dos objetos
        
        public override Boolean Persistir()
        {
            Morador objTelefonesDAO = new TelefonesDAO();
            if (objTelefonesDAO.persistir(this))
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
            TelefonesDAO objTelefonesDAO = new TelefonesDAO();
            if (objTelefonesDAO.atualizar(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

         public static Apartamento RecuperaObj(String ID)
        {
            Apartamento objTelefone = TelefonesDAO.recuperaObj(pID);
            return objApartamento;
        }

        public static IList RecuperaObjetos()
        {
            IList listTelefones = TelefonesDAO.recuperaObj();
            return listTelefones;
        }

        public static Boolean Excluir(String pID)
        {
            return TelefonesDAO.excluir(pID);
        }
    #endregion
    }
}
