using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ControleCondominio.Model;

namespace ControleCondominio.Controller
{
    class cntrLocatario
    {
        private Locatario objLocatario;
        public cntrLocatario()
        {
        }
        public Boolean Salvar(ArrayList pLista)
        {
            if (pLista[0] == null)
            {
                //Criar um Novo
                this.objLocatario = new Locatario();
                this.objLocatario.Codigo = System.Guid.NewGuid().ToString();
                this.objLocatario.Nome = Convert.ToString(pLista[1]);
                this.objLocatario.CPF = Convert.ToString(pLista[2]);
                this.objLocatario.Departamento = Departamento.RecuperaObjeto(Convert.ToString(pLista[3]));
                this.objLocatario.NumDiasTrabalhados = Convert.ToInt16(pLista[4]);
                this.objLocatario.NumHorasDiaTrabalhado = Convert.ToInt16(pLista[5]);
                this.objLocatario.ValorHora = Convert.ToInt16(pLista[6]);
                if (objLocatario.Persistir())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //Atualização
                this.objLocatario =
               (FuncionarioHorista)Funcionario.RecuperaObjeto(pLista[0].ToString());
                this.objLocatario.Nome = Convert.ToString(pLista[1]);
                this.objLocatario.CPF = Convert.ToString(pLista[2]);
                this.objLocatario.Departamento = Departamento.RecuperaObjeto(Convert.ToString(pLista[3]));
                this.objLocatario.NumDiasTrabalhados = Convert.ToInt32(pLista[4]);
                this.objLocatario.NumHorasDiaTrabalhado = Convert.ToInt32(pLista[5]);
                this.objLocatario.ValorHora = Convert.ToInt32(pLista[6]);
                if (objLocatario.Atualizar())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public ArrayList RecuperaObjeto(String pOID)
        {
            ArrayList vetEnvia = new ArrayList();
            this.objLocatario =
           (FuncionarioHorista)Funcionario.RecuperaObjeto(pOID);
            vetEnvia.Add(this.objLocatario.Codigo);
            vetEnvia.Add(this.objLocatario.Nome);
            vetEnvia.Add(this.objLocatario.CPF);
            vetEnvia.Add(this.objLocatario.Departamento.Codigo);
            vetEnvia.Add(this.objLocatario.NumDiasTrabalhados);
            vetEnvia.Add(this.objLocatario.NumHorasDiaTrabalhado);
            vetEnvia.Add(this.objLocatario.ValorHora);
            return vetEnvia;
        }
    }
}


