using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ControleCondominio.Model;

namespace ControleCondominio.Controller
{
    class cntrDonoDoImovel
    {
        private DonoDoImovel objLocatario;
        public cntrDonoDoImovel()
        {
        }
        public Boolean Salvar(ArrayList pLista)
        {
            if (pLista[0] == null)
            {
                //Criar um Novo
                this.objLocatario = new DonoDoImovel();
                this.objLocatario.Id = Convert.ToInt16(pLista[1]);
                this.objLocatario.Nome = Convert.ToString(pLista[2]);
                this.objLocatario.Cpf = Convert.ToString(pLista[3]);
                this.objLocatario.QtdApartamentos = Convert.ToInt16(pLista[4]);
                this.objLocatario.Telefone = Convert.ToString(pLista[5]);
                this.objLocatario.Apartamento = Apartamento.RecuperaObj(Convert.ToString(pLista[6]));

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
                this.objLocatario.Id = Convert.ToInt16(pLista[1]);
                this.objLocatario.Nome = Convert.ToString(pLista[2]);
                this.objLocatario.Cpf = Convert.ToString(pLista[3]);
                this.objLocatario.QtdApartamentos = Convert.ToInt16(pLista[4]);
                this.objLocatario.Telefone = Convert.ToString(pLista[5]);
                this.objLocatario.Apartamento = Apartamento.RecuperaObj(Convert.ToString(pLista[6]));
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
        public ArrayList RecuperaObj(String pOID)
        {
            ArrayList vetEnvia = new ArrayList();
            this.objLocatario = (DonoDoImovel)Pessoa.RecuperaObj(pOID);
            vetEnvia.Add(this.objLocatario.Id);
            vetEnvia.Add(this.objLocatario.Nome);
            vetEnvia.Add(this.objLocatario.Cpf);

            vetEnvia.Add(this.objLocatario.Apartamento.Id);
            vetEnvia.Add(this.objLocatario.QtdApartamentos);
            vetEnvia.Add(this.objLocatario.Telefone);
            return vetEnvia;
        }
    }
}


