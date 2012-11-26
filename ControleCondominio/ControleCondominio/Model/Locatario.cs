using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCondominio.Model
{
    class Locatario:Pessoa
    {
       private int qtdApartamentos;
        private Apartamento apartamento;
        private Telefones telefone;

        #region gets e sets
        public int QtdApartamentos
        {
            get { return this.qtdApartamentos; }
            set { this.qtdApartamentos = value; }
        }

        public Apartamento Apartamento
        {
            get { return this.apartamento; }
            set { this.apartamento = value; }
        }
        #endregion

        #region Construtores
        public Locatario(String pnome, String pCPF, String pemail, int pqtdApartamentos)
            :base(pnome, pCPF,pemail){
                this.qtdApartamentos=pqtdApartamentos;
            }
        public Locatario()//contruttor padrao
        {
        }
        #endregion

        #region métodos responsáveis pela persistência e manipulação dos objetos
        public override Boolean Persistir()
        {
            Morador objLocatarioDAO = new LocatarioDAO();
            if (objLocatarioDAO.persistir(this))
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
            LocatarioDAO objLocatarioDAO = new LocatarioDAO();
            if (objLocatarioDAO.atualizar(this))
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
