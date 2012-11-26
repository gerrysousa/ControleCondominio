using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleCondominio.Model;

namespace ControleCondominio.Model
{
    class Apartamento
    {
        private int ID;
        private int numero;
        private Condominio condominio;
        private Morador locador;
        private Locatario locatario;

        #region Construtores
        public Apartamento(int pnumero)
        {
            this.numero = pnumero;
            this.condominio = new Condominio();
            this.locador = new Morador();
            this.locatario = new Locatario();
        }
        public Apartamento()//contruttor padrao
        {
        }
        #endregion

        #region gets e sets
        public int IDs
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

        public Locatario Locatario
        {
            get { return this.locatario; }
            set { this.locatario = value; }
        }
        #endregion 

        #region métodos responsáveis pela persistência e manipulação dos objetos

        public Boolean Persistir()
        {
            Morador objApartamentoDao = new ApartamentoDao();
            if (objApartamentoDao.persistir(this))
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
            ApartamentoDao objApartamentoDao = new ApartamentoDao();
            if (objApartamentoDao.atualizar(this))
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
            Apartamento objApartamento = ApartamentoDao.recuperaObj(pID);
            return objApartamento;
        }

        public static IList RecuperaObjetos()
        {
            IList listApartamentos = ApartamentoDao.recuperaObj();
            return listApartamentos;
        }

        public static Boolean Excluir(String pID)
        {
            return ApartamentoDao.excluir(pID);
        }

    #endregion
    }
}
