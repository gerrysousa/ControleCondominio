using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleCondominio.Dao
{
    public class FabricaConexao
    {
        private String stringconnection = "Data Source=\\SQLEXPRESS;Initial Catalog=Empresa;Integrated Security=SSPI;MultipleActiveResultSets=True";
        private static SqlConnection objConexao = null;

        public FabricaConexao()
        {
            objConexao = new SqlConnection();
            objConexao.ConnectionString = stringconnection;
            objConexao.Open();
        }
        public static SqlConnection getConexao()
        {
            if (objConexao == null)
            {
                new FabricaConexao();
            }
            return objConexao;
        }
        public static void fecharConexao()
        {
            objConexao.Close();
        }
    }
}
