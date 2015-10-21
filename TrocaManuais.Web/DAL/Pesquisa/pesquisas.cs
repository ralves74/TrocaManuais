using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrocaManuais.Web.DAL.Pesquisa
{
    public class pesquisas
    {
        private TrocaManuais.Web.Models.TrocamanuaisEntities dbcontext = new TrocaManuais.Web.Models.TrocamanuaisEntities();

        public pesquisas(TrocaManuais.Web.Models.TrocamanuaisEntities _dbContext)

        {

            this.dbcontext = _dbContext;

        }
        public List<TrocaManuais.Web.Models.ManuaisEstabelecimentos> manuaisporEstabelecimento(string Estab, string Anol)
        {
            var ttt = new TrocaManuais.Web.Models.ManuaisEstabelecimentos();
            List<TrocaManuais.Web.Models.ManuaisEstabelecimentos> lista = new List<TrocaManuais.Web.Models.ManuaisEstabelecimentos>();
            lista = (from man in dbcontext.ManuaisEstabelecimentos where man.Aletivo == Anol && man.estab == Estab select man).ToList<TrocaManuais.Web.Models.ManuaisEstabelecimentos>();
            return lista;
        }

        public IList<TrocaManuais.Web.Models.Agrupamentos> GetAllAgrupamentos()
        {
            var query = (from agrup in dbcontext.Agrupamentos select agrup).ToList<TrocaManuais.Web.Models.Agrupamentos>();
            return query;
        }
       
        public IList<TrocaManuais.Web.Models.estabelecimentos> GetAllEstabByAgrupID(int AgrupId)
        {
            var query = (from estab in dbcontext.estabelecimentos where estab.CodAgrupamento == AgrupId select estab).ToList<TrocaManuais.Web.Models.estabelecimentos>();
            return query;
        }
    }
}