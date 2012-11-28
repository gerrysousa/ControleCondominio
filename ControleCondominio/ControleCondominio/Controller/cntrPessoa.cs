using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ControleCondominio.Model;

namespace ControleCondominio.Controller
{
    class cntrPessoa
    {

        public cntrPessoa()
        {
        }
        public static ArrayList RecuperaObjetos()
        {
            ArrayList vetEnviaPessoas = new ArrayList();
            IList listPessoas = Pessoa.RecuperaObjetos();
            for (int i = 0; i < listPessoas.Count; i++)
            {
                Pessoa objBuffer = (Pessoa)listPessoas[i];
                String[] vBuffer = new String[5];
                vBuffer[0] = Convert.ToString(objBuffer.Id);
                vBuffer[1] = objBuffer.Nome;
                vBuffer[2] = objBuffer.Cpf;
                vBuffer[4] = objBuffer.Email;
                //vBuffer[5] = objBuffer.Departamento.Descricao;
                if (objBuffer is Morador)
                {
                    vBuffer[3] = "Morador";
                }
                else if (objBuffer is DonoDoImovel)
                {
                    vBuffer[3] = "Locatario";
                }
                else if (objBuffer is Visitante)
                {
                    vBuffer[3] = "Visitante";
                }
                else if (objBuffer is Usuario)
                {
                    vBuffer[3] = "Usuario";
                }

                vetEnviaPessoas.Add(vBuffer);
            }
            return vetEnviaPessoas;
        }
        public static ArrayList RecuperaObjetosPorTipo(Object ptipo)
        {
            ArrayList vetEnviaPessoas = new ArrayList();
            IList listPessoas = Pessoa.RecuperaObjetosPorTipo(ptipo);
            for (int i = 0; i < listPessoas.Count; i++)
            {
                Pessoa objBuffer = (Pessoa)listPessoas[i];
                String[] vBuffer = new String[5];
                vBuffer[0] = Convert.ToString(objBuffer.Id);
                vBuffer[1] = objBuffer.Nome;
                vBuffer[2] = objBuffer.Cpf;
                vBuffer[4] = objBuffer.Email;
                vetEnviaPessoas.Add(vBuffer);
            }
            return vetEnviaPessoas;
        }

        public static ArrayList RecuperaObjetosPorApartamento(int pID)
        {
            ArrayList vetEnviaPessoas = new ArrayList();
            IList listPessoas = Pessoa.RecuperaObjetosPorApartamento(pID);
            for (int i = 0; i < listPessoas.Count; i++)
            {
                Pessoa objBuffer = (Pessoa)listPessoas[i];
                String[] vBuffer = new String[5];
                vBuffer[0] = Convert.ToString(objBuffer.Id);
                vBuffer[1] = objBuffer.Nome;
                vBuffer[2] = objBuffer.Cpf;
                vBuffer[4] = objBuffer.Email;

                vetEnviaPessoas.Add(vBuffer);
            }
            return vetEnviaPessoas;
        }

        public static Boolean Excluir(String pID)
        {
            return Pessoa.Excluir(pID);
        }
        public static int ContabilizaFuncionariosPorDepartamento(String pIDDepartamento)
        {
            return
           PessoaDAO.ContabilizaFuncionariosPorDepartamento(pIDDepartamento);
        }
    }
}

