using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrocaManuais.Web.DAL.Mensagens
{
    public class VerMensagens
    {
        private TrocaManuais.Web.Models.TrocamanuaisEntities dbcontext = new TrocaManuais.Web.Models.TrocamanuaisEntities();

        public VerMensagens(TrocaManuais.Web.Models.TrocamanuaisEntities _dbContext)

        {

            this.dbcontext = _dbContext;

        }

        /*
         * Metodo de criação de lista de mensagens de enviadas e recebidas por um utiliador
         */

        public List<TrocaManuais.Web.Models.Mensagens> TodasMensagens(string Nome)
        {
            var ttt = new TrocaManuais.Web.Models.Mensagens();
            List<TrocaManuais.Web.Models.Mensagens> lista = new List<TrocaManuais.Web.Models.Mensagens>();
            lista = (from mens in dbcontext.Mensagens where mens.Nickname == Nome || mens.NickEnviado == Nome select mens).ToList<TrocaManuais.Web.Models.Mensagens>();
            return lista;
        }

        /*
        * Metodo de criação de lista de mensagens de enviadas por um utiliador
        */
        public List<TrocaManuais.Web.Models.Mensagens> MensagensEnviadas(string Nome)
        {
            var ttt = new TrocaManuais.Web.Models.Mensagens();
            List<TrocaManuais.Web.Models.Mensagens> lista = new List<TrocaManuais.Web.Models.Mensagens>();
            lista = (from mens in dbcontext.Mensagens where mens.Nickname == Nome  select mens).ToList<TrocaManuais.Web.Models.Mensagens>();
            return lista;
        }

        /*
       * Metodo de criação de lista de mensagens de enviadas por um utiliador
       */
        public List<TrocaManuais.Web.Models.Mensagens> MensagensRecebidas(string Nome)
        {
            var ttt = new TrocaManuais.Web.Models.Mensagens();
            List<TrocaManuais.Web.Models.Mensagens> lista = new List<TrocaManuais.Web.Models.Mensagens>();
            lista = (from mens in dbcontext.Mensagens where mens.NickEnviado == Nome select mens).ToList<TrocaManuais.Web.Models.Mensagens>();
            return lista;
        }


    }
}