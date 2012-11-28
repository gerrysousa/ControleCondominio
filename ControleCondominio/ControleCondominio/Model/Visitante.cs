using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleCondominio.Dao;

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
            VisitanteDAO objVisitanteDAO = new VisitanteDAO();
            if (objVisitanteDAO.Persistir(this))
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
            VisitanteDAO objVisitanteDAO = new VisitanteDAO();
            if (objVisitanteDAO.Atualizar(this))
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
