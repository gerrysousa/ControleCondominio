using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCondominio.Model
{
    class Usuario : Pessoa
    {

        private string login;
        private string senha;

        #region gets e sets
        public string Login
        {
            get { return this.login; }
            set { this.login = value; }
        }

        public string Senha
        {
            get { return this.senha; }
            set { this.senha = value; }
        }

        #endregion

        #region Construtores
        public Usuario(String pnome, String pCPF, String pemail, string plogin, string psenha)
            : base(pnome, pCPF, pemail)
        {
            this.login = plogin;
            this.senha = psenha;
        }
        public Usuario()//contruttor padrao
        {
        }
        #endregion

        #region métodos responsáveis pela persistência e manipulação dos objetos
        public override Boolean Persistir()
        {
            Morador objUsuarioDAO = new UsuarioDAO();
            if (objUsuarioDAO.persistir(this))
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
            UsuarioDAO objUsuarioDAO = new UsuarioDAO();
            if (objUsuarioDAO.atualizar(this))
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
