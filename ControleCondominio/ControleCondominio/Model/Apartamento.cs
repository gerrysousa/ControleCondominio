using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleCondominio.Model;
using System.Collections;
using ControleCondominio.Dao;

namespace ControleCondominio.Model
{
    class Apartamento
    {
        private int ID;
        private int numero;
        private Condominio condominio;
        private Morador locador;
        private DonoDoImovel locatario;

        #region Construtores
        public Apartamento(int pnumero)
        {
            this.numero = pnumero;
            this.condominio = new Condominio();
            this.locador = new Morador();
            this.locatario = new DonoDoImovel();
        }
        public Apartamento()//contruttor padrao
        {
        }
        #endregion

        #region gets e sets
        public int Id
        {
            get { return this.ID; }
            set { this.ID = value; }
        }

        public int Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }

        public Condominio Condominio
        {
            get { return this.condominio; }
            set { this.condominio = value; }
        }

        public Morador Locador
        {
            get { return this.locador; }
            set { this.locador = value; }
        }

        public DonoDoImovel Locatario
        {
            get { return this.locatario; }
            set { this.locatario = value; }
        }
        #endregion 

        #region métodos responsáveis pela persistência e manipulação dos objetos

        public Boolean Persistir()
        {
            ApartamentoDAO objApartamentoDao = new ApartamentoDAO();
            if (objApartamentoDao.Persistir(this))
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
            ApartamentoDAO objApartamentoDao = new ApartamentoDAO();
            if (objApartamentoDao.Atualizar(this))
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
            Apartamento objApartamento = ApartamentoDAO.RecuperaObj(pID);
            return objApartamento;
        }

        public static IList RecuperaObjetos()
        {
            IList listApartamentos = ApartamentoDAO.RecuperaObj();
            return listApartamentos;
        }

        public static Boolean Excluir(String pID)
        {
            return ApartamentoDAO.Excluir(pID);
        }

    #endregion
    }
}
