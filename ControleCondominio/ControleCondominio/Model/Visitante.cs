using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCondominio.Model
{
    class Visitante:Pessoa
    {
        private string descriçao;
               
        #region gets e sets
        public string Descriçao
        {
            get { return this.descriçao; }
            set { this.descriçao = value; }
        }

        #endregion

        #region Construtores
        public Visitante(String pnome, String pCPF, String pemail, string pdescricao)
            :base(pnome, pCPF,pemail){
                this.descriçao = pdescricao;
            }
        public Visitante()//contruttor padrao
        {
        }
        #endregion

        #region métodos responsáveis pela persistência e manipulação dos objetos
        public override Boolean Persistir()
        {
            Morador objVisitanteDAO = new VisitanteDAO();
            if (objVisitanteDAO.persistir(this))
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
            DAO objMoradorDAO = new VisitanteDAO();
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
