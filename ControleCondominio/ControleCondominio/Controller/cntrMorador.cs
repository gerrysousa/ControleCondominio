using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ControleCondominio.Model;

namespace ControleCondominio.Controller
{
    class cntrMorador
    {
         private Morador objMorador;
         public cntrMorador()
        {
        }
        public Boolean Salvar(ArrayList pLista)
        {
            if (pLista[0] == null)
            {
                //Criar um Novo
                this.objMorador = new Morador();
               // this.objMorador.Id = Convert.ToInt16(pLista[0]);
                this.objMorador.Nome = Convert.ToString(pLista[1]);
                this.objMorador.Cpf = Convert.ToString(pLista[2]);
                this.objMorador.Email = Convert.ToString(pLista[3]);
                this.objMorador.Telefone = Convert.ToString(pLista[4]);
                this.objMorador.IsResponsavel = Convert.ToBoolean(pLista[5]);
                this.objMorador.Apartamento = Apartamento.RecuperaObj(Convert.ToString(pLista[6]));

                if (objMorador.Persistir())
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
                this.objMorador.Nome = Convert.ToString(pLista[1]);
                this.objMorador.Cpf = Convert.ToString(pLista[2]);
                this.objMorador.Email = Convert.ToString(pLista[3]);
                this.objMorador.Telefone = Convert.ToString(pLista[4]);
                this.objMorador.IsResponsavel = Convert.ToBoolean(pLista[5]);
                this.objMorador.Apartamento = Apartamento.RecuperaObj(Convert.ToString(pLista[6]));
                
                if (objMorador.Atualizar())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public ArrayList RecuperaObj(int pOID)
        {
            ArrayList vetEnvia = new ArrayList();
            this.objMorador = Morador.RecuperaObj(pOID);
            vetEnvia.Add(this.objMorador.Id);
            vetEnvia.Add(this.objMorador.Nome);
            vetEnvia.Add(this.objMorador.Cpf);
            vetEnvia.Add(this.objMorador.Apartamento.Id);
            vetEnvia.Add(this.objMorador.Telefone);
            return vetEnvia;
        }

        public Morador RecuperaObj2(int pOID)
        {
            this.objMorador = Morador.RecuperaObj(pOID);
            return objMorador;
        }

        public static IList RecuperaObjetos()
        {
            IList ListMoradores = Morador.RecuperaObjetos();
            return ListMoradores;
        }
               
    }
}
