using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ControleCondominio.Model;
using System.Collections;
using ControleCondominio.Controller;

namespace ControleCondominio.Dao
{
    class PessoaDAO
    {
        public PessoaDAO()
        {
        }

        public static void PreencheDadosObj(int pID, Pessoa pessoa)
        {
            SqlConnection objConexao = FabricaConexao.getConexao();
            String strQuery = "SELECT ID, Nome, CPF, email FROM Pessoa WHERE ID = '" + pID + "'";
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);
            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    pessoa.Id = Convert.ToInt32(objLeitor[0]);
                    pessoa.Nome = Convert.ToString(objLeitor[1]);
                    pessoa.Cpf = Convert.ToString(objLeitor[2]);
                    pessoa.Email = Convert.ToString(objLeitor[3]);
                }
                objLeitor.Close();
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
            }
        }

        public static Pessoa RecuperaObj(int pID)
        {
            SqlConnection objConexao = FabricaConexao.getConexao();
            String strQuery = "SELECT ID, Nome, CPF, email FROM Pessoa WHERE ID = '" + pID + "'";
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao); 
            cntrApartamento objControllerApartamento = new cntrApartamento();
            SqlDataReader objLeitor2;
            Pessoa objPessoa = null;
            Morador objMorador;
            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    //Verificar Tipo do Funcionário e Recuperar o Restante do Funcionário
                    //Tentar em Todos os Filhos, até encontrar a Chave Primária Estrangeira Igual
                    strQuery = "SELECT ID, IsResponsavel, apartamento FROM Morador WHERE ID = '" + objLeitor[0] + "'";
                    objCommand = new SqlCommand(strQuery, objConexao);
                    objCommand.ExecuteNonQuery();
                    objLeitor2 = objCommand.ExecuteReader();
                    while (objLeitor2.Read())
                    {
                        objMorador = new Morador();
                        objMorador.IsResponsavel = Convert.ToBoolean(objLeitor2[1]);
                        objMorador.Id = Convert.ToInt32(objLeitor2[3]);
                        objMorador.Email = Convert.ToString(objLeitor[0]);
                        objMorador.Nome = Convert.ToString(objLeitor[1]);
                        objMorador.Cpf = Convert.ToString(objLeitor[2]);
                        objMorador.Apartamento = objControllerApartamento.RecuperaObj(Convert.ToString(objLeitor[3]));
                        objPessoa = (Pessoa)objMorador;
                    }
                    //Fim Tentativas de Descobrir Tipo Funcionário
                }
                objLeitor.Close();
                return objPessoa;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return objPessoa;
            }
        }

        public static IList RecuperaObjetosPorApartamento(String pOID)
        {
            IList listPessoas = new ArrayList();
            SqlConnection objConexao = FabricaConexao.FabricaConexao.getConexao();
            String strQuery = "SELECT ID, Nome, CPF, email, ApartamentoOID FROM Pessoa WHERE ApartamentoOID = '" + pOID + "'";
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);
            cntrApartamento objControllerApartamento = new cntrApartamento();
            SqlDataReader objLeitor2;
            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    //Verificar Tipo do Funcionário e Recuperar o Restante do Funcionário
                    //Tentar em Todos os Filhos, até encontrar a Chave Primária Estrangeira Igual
                    strQuery = "SELECT ID, NumDiasTrabalhados,NumHorasDiaTrabalhado, ValorHora FROM FuncionarioHorista WHERE ID = '" + objLeitor[0] + "'";
                    objCommand = new SqlCommand(strQuery, objConexao);
                    objCommand.ExecuteNonQuery();
                    objLeitor2 = objCommand.ExecuteReader();
                    while (objLeitor2.Read())
                    {
                        Morador objMorador = new Morador();
                        objMorador.IsResponsavel = Convert.ToBoolean(objLeitor2[1]);
                        objMorador.Id = Convert.ToInt32(objLeitor2[3]);
                        objMorador.Email = Convert.ToString(objLeitor[0]);
                        objMorador.Nome = Convert.ToString(objLeitor[1]);
                        objMorador.Cpf = Convert.ToString(objLeitor[2]);
                        objMorador.Apartamento = objControllerApartamento.RecuperaObj(Convert.ToString(objLeitor[3]));
                        
                        listPessoas.Add(objPessoa);
                    }
                    //Fim Tentativas de Descobrir Tipo Funcionário
                }
                objLeitor.Close();
                return listPessoas;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return listPessoas;
            }
        }
        
        public static IList RecuperaObjetosPorTipo(String pOID)
        {
            IList listFuncionarios = new ArrayList();
            SqlConnection objConexao = FabricaConexao.getConexao();
            String strQuery = "SELECT ID, Nome, CPF, DepartamentoOID FROM Funcionario WHERE DepartamentoOID = '" + pOID + "'";
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);
            cntrApartamento objControllerApartamento = new cntrApartamento();
            SqlDataReader objLeitor2;
            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    //Verificar Tipo do Funcionário e Recuperar o Restante do Funcionário
                    //Tentar em Todos os Filhos, até encontrar a Chave Primária Estrangeira Igual
                    strQuery = "SELECT ID, NumDiasTrabalhados,NumHorasDiaTrabalhado, ValorHora FROM FuncionarioHorista WHERE ID = '" + objLeitor[0] + "'";
                    objCommand = new SqlCommand(strQuery, objConexao);
                    objCommand.ExecuteNonQuery();
                    objLeitor2 = objCommand.ExecuteReader();
                    while (objLeitor2.Read())
                    {
                        Morador objFuncionario = new Morador();
                        objFuncionario.NumDiasTrabalhados = Convert.ToInt32(objLeitor2[1]);
                        objFuncionario.NumHorasDiaTrabalhado = Convert.ToInt32(objLeitor2[2]);
                        objFuncionario.ValorHora = Convert.ToInt32(objLeitor2[3]);
                        objFuncionario.Codigo = Convert.ToString(objLeitor[0]);
                        objFuncionario.Nome = Convert.ToString(objLeitor[1]);
                        objFuncionario.CPF = Convert.ToString(objLeitor[2]);
                        objFuncionario.Departamento = objControllerApartamento.RecuperaObjetoObjeto(Convert.ToString(objLeitor[3]));
                        listFuncionarios.Add(objFuncionario);
                    }
                    //Fim Tentativas de Descobrir Tipo Funcionário
                }
                objLeitor.Close();
                return listFuncionarios;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return listFuncionarios;
            }
        }
        
        public static IList RecuperaObjetos()
        {
            IList listFuncionarios = new ArrayList();
            SqlConnection objConexao = FabricaConexao.getConexao();
            String strQuery = "SELECT ID, Nome, CPF, DepartamentoOID FROM Funcionario";
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);
            cntrDepartamento objControllerDepartamento = new cntrDepartamento();
            SqlDataReader objLeitor2;
            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    //Verificar Tipo do Funcionário e Recuperar o Restante do Funcionário
                    //Tentar em Todos os Filhos, até encontrar a Chave Primária Estrangeira Igual
                    strQuery = "SELECT ID, NumDiasTrabalhados, NumHorasDiaTrabalhado, ValorHora FROM FuncionarioHorista WHERE ID = '" + objLeitor[0] + "'";
                    objCommand = new SqlCommand(strQuery, objConexao);
                    objCommand.ExecuteNonQuery();
                    objLeitor2 = objCommand.ExecuteReader();
                    while (objLeitor2.Read())
                    {
                        Morador objFuncionario = new Morador();
                        objFuncionario.NumDiasTrabalhados = Convert.ToInt32(objLeitor2[1]);
                        objFuncionario.NumHorasDiaTrabalhado = Convert.ToInt32(objLeitor2[2]);
                        objFuncionario.ValorHora = Convert.ToInt32(objLeitor2[3]);
                        objFuncionario.Codigo = Convert.ToString(objLeitor[0]);
                        objFuncionario.Nome = Convert.ToString(objLeitor[1]);
                        objFuncionario.CPF = Convert.ToString(objLeitor[2]);
                        objFuncionario.Departamento = objControllerDepartamento.RecuperaObjetoObjeto(Convert.ToString(objLeitor[3]));
                        listFuncionarios.Add(objFuncionario);
                    }
                    //Fim Tentativas de Descobrir Tipo Funcionário
                }
                objLeitor.Close();
                return listFuncionarios;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return listFuncionarios;
            }
        }
        
        public static Boolean Excluir(String pID)
        {
            SqlConnection objConexao = FabricaConexao.getConexao();
            //Criar query para deletar o funcionario associado. Criar query para todos os tipos.
            String strQuery = "DELETE FROM Funcionario WHERE ID = '" + pID + "'";
            strQuery = strQuery + "; DELETE FROM FuncionarioHorista WHERE ID = '" + pID + "'";
            //Caso tivesse mais tipos, adicionar a query para todos os tipos, por exemplo FuncionarioDiarista caso existisse:
            //strQuery = strQuery + "; DELETE FROM FuncionarioDiarista WHERE ID = '" + pID + "'";
            //Desta forma todo tipo de funcionário seria deletado, sem que seja necessário descobrir o seu tipo específico. A query não retorna erro quando não encontra o objeto na clausula WHERE
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);
            try
            {
                objCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return false;
            }
        }
        
        public static int ContabilizaFuncionariosPorDepartamento(String pIDDepartamento)
        {
            SqlConnection objConexao = FabricaConexao.getConexao();
            String strQuery = "SELECT COUNT(*) FROM Funcionario WHERE DepartamentoOID = '" + pIDDepartamento + "'";
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);
            int vRetorno = 0;
            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    vRetorno = Convert.ToInt32(objLeitor[0]);
                }
                return vRetorno;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return vRetorno;
            }
        }
    }
}

