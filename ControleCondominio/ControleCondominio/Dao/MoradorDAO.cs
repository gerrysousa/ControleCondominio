using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleCondominio.Model;
using System.Data.SqlClient;
using System.Collections;

namespace ControleCondominio.Dao
{
    class MoradorDAO
    {
        public MoradorDAO()
        {
        }
        public Boolean Persistir(Morador pMorador)
        {
            SqlConnection objConexao = FabricaConexao.getConexao();
            String strQuery = "INSERT INTO Morador VALUES('" + pMorador.Id + "','" + pMorador.Nome + "','" + pMorador.Cpf +
                "','" + pMorador.Email + "','" + pMorador.Telefone + "','" + pMorador.IsResponsavel + "','" + pMorador.Apartamento.Id + "')";
            
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

        public Boolean Atualizar(Morador pMorador)
        {
            SqlConnection objConexao = FabricaConexao.getConexao();
            String strQuery = "UPDATE Morador SET Nome = '" + pMorador.Nome + "', CPF = '" + pMorador.Cpf + "',Email = '" + pMorador.Email + "',Telefone = '" + pMorador.Telefone 
                + "', ApartamentoOID = '" + pMorador.Apartamento.Id + "'WHERE ID = '" + pMorador.Id + "'";
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

        public static Morador RecuperaObj(int pID)
        {
            SqlConnection objConexao = FabricaConexao.getConexao();
            SqlCommand objCommand;
            SqlDataReader objLeitor;
            Morador objMorador = null;
            try
            {
                String strQuery = "SELECT ID, nome, CPF, email, Telefone, IsResponsavel, Apartamento FROM Morador WHERE ID = '" + pID + "'";
                objCommand = new SqlCommand(strQuery, objConexao);
                objCommand.ExecuteNonQuery();
                objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    objMorador = new Morador();
                    objMorador.Id = Convert.ToInt32(objLeitor[0]);
                    objMorador.Nome =Convert.ToString(objLeitor[1]);
                    objMorador.Cpf = Convert.ToString(objLeitor[2]);
                    objMorador.Email = Convert.ToString(objLeitor[3]);
                    objMorador.Telefone = Convert.ToString(objLeitor[4]);
                    objMorador.IsResponsavel = Convert.ToBoolean(objLeitor[5]);
                    objMorador.Apartamento.Id = Convert.ToInt32(objLeitor[6]);                                
                }
                objLeitor.Close();
                return objMorador;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return objMorador;
            }
        }

        public static IList RecuperaObjetos()
        {
            IList listMoradores = new ArrayList();
            SqlConnection objConexao = FabricaConexao.getConexao();
            SqlCommand objCommand;
            SqlDataReader objLeitor;
            Morador objMorador = null;
            try
            {
                String strQuery = "SELECT ID, nome, CPF, email, Telefone, IsResponsavel, Apartamento FROM Morador";
                objCommand = new SqlCommand(strQuery, objConexao);
                objCommand.ExecuteNonQuery();
                objLeitor = objCommand.ExecuteReader();


                while (objLeitor.Read())
                {
                    objMorador = new Morador();
                    objMorador.Id = Convert.ToInt32(objLeitor[0]);
                    objMorador.Nome = Convert.ToString(objLeitor[1]);
                    objMorador.Cpf = Convert.ToString(objLeitor[2]);
                    objMorador.Email = Convert.ToString(objLeitor[3]);
                    objMorador.Telefone = Convert.ToString(objLeitor[4]);
                    objMorador.IsResponsavel = Convert.ToBoolean(objLeitor[5]);
                    objMorador.Apartamento.Id = Convert.ToInt32(objLeitor[6]);

                    listMoradores.Add(objMorador);
                }
                objLeitor.Close();
                return listMoradores;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return listMoradores;
;
            }
        }
    }
}
