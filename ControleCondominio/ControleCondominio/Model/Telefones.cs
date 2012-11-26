using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public Telefones(String pnome, String pCPF, String pemail, bool pIsResponsavel)
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
            MoradorDAO objMoradorDAO = new MoradorDAO();
            if (objMoradorDAO.atualizar(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
