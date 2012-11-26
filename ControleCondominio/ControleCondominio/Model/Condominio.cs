using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCondominio.Model
{
    class Condominio
    {        
        private int ID;
        private string nome;
        private string descricao;        
      
        #region Construtores
        public Condominio(string pnome, string pdescricao)
        {
            this.nome = pnome;
            this.descricao = pdescricao;
        }
        public Condominio()//contruttor padrao
        {
        }
        #endregion

        #region gets e sets
        public int IDs
        {
            get { return this.ID; }
            set { this.ID = value; }
        }

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public string Descricao
        {
            get { return this.descricao; }
            set { this.descricao = value; }
        }

        #endregion 

        #region métodos responsáveis pela persistência e manipulação dos objetos

        public Boolean Persistir()
        {
            Morador objCondominioDao = new CondominioDao();
            if (objCondominioDao.persistir(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Atualizar()
        {
            CondominioDao objCondominioDao = new CondominioDao();
            if (objCondominioDao.atualizar(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Condominio RecuperaObj(String ID)
        {
            Condominio objCondominio = CondominioDao.recuperaObj(pID);
            return objCondominio;
        }

        public static IList RecuperaObjetos()
        {
            IList listCondominios = CondominioDao.recuperaObj();
            return listCondominios;
        }

        public static Boolean Excluir(String pID)
        {
            return CondominioDao.excluir(pID);
        }

    #endregion
    }
}
