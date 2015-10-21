using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocaManuais.Web;
using System.Data;
using System.Data.Entity;

namespace TrocaManuais.DAL.ManuaisPorEscalao
{
    public class ManuaisPorEscalao
    {

        private TrocaManuais.Web.Models.TrocamanuaisEntities dbcontext;

        public ManuaisPorEscalao(TrocaManuais.Web.Models.TrocamanuaisEntities _dbContext)

        {

            this.dbcontext = _dbContext;

        }

       /* public IEnumerable<TrocaManuais.Web.Models.ManuaisPorEscalaoViewModels> AllManuaisPorEscalao(string escalao)
        {
            try
            {
                using (TrocaManuais.Web.Models.TrocamanuaisEntities db = new TrocaManuais.Web.Models.TrocamanuaisEntities())
                {
                   
                    return db.mrobProducts.Where(x => x.Status == status).Select(x => new Product
                    {
                        Name = x.Name,
                        Desc = x.Description,
                        Price = x.Price
                    }).OrderBy(x => x.Name);
                }
            }
            catch
            {
                return null;
            }
        }*/
    }
}
