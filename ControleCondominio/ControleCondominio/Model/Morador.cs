using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCondominio.Model
{
    class Morador:Pessoa
    {
        private Boolean isResponsavel;
        private Apartamento apartamento;

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
            Morador objMoradorDAO = new MoradorDAO();
            if (objMoradorDAO.persistir(this))
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
