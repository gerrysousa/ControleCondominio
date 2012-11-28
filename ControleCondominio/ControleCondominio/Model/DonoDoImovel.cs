using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleCondominio.Dao;

namespace ControleCondominio.Model
{
    class DonoDoImovel:Pessoa
    {
        private int qtdApartamentos;
        private Apartamento apartamento;
        private string telefone;

        #region gets e sets
        public int QtdApartamentos
        {
            get { return this.qtdApartamentos; }
            set { this.qtdApartamentos = value; }
        }

        public string Telefone
        {
            get { return this.telefone; }
            set { this.telefone = value; }
        }

        public Apartamento Apartamento
        {
            get { return this.apartamento; }
            set { this.apartamento = value; }
        }
        #endregion

        #region Construtores
        public DonoDoImovel(String pnome, String pCPF, String pemail, int pqtdApartamentos)
            :base(pnome, pCPF,pemail){
                this.qtdApartamentos=pqtdApartamentos;
            }
        public DonoDoImovel()//contruttor padrao
        {
        }
        #endregion

        #region métodos responsáveis pela persistência e manipulação dos objetos
       
        public override Boolean Persistir()
        {
            DonoDoImovelDAO objDonoDoImovelDAO = new DonoDoImovelDAO();
            if (objDonoDoImovelDAO.Persistir(this))
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
            DonoDoImovelDAO objLocatarioDAO = new DonoDoImovelDAO();
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
