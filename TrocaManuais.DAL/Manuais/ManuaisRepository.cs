using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using TrocaManuais.Web;

namespace TrocaManuais.DAL.Manuais
{
    public class ManuaisRepository
    {
        private TrocaManuais.Web.Models.TrocamanuaisEntities dbcontext;

        public ManuaisRepository(TrocaManuais.Web.Models.TrocamanuaisEntities _dbContext)

        {

            this.dbcontext = _dbContext;

        }

        public int GetMaxIdManual()
        {
            int maxid = 0;
            var ttt = new TrocaManuais.Web.Models.TrocamanuaisEntities();
            //using (var ttt = new TrocaManuais.Domain.tmanuaisEntities())
            //{
            int maximo = (from c in ttt.manuais select c.idmanual).DefaultIfEmpty(0).Max();
            maxid = ++maximo;
            //}
            return maxid;
        }

        public void SaveNewManual(TrocaManuais.Web.Models.manuais Manuais)
        {
            var db = new TrocaManuais.Web.Models.TrocamanuaisEntities();
            Manuais.idmanual = GetMaxIdManual();
            db.manuais.Add(Manuais);
            db.SaveChanges();
        }

        public IList<TrocaManuais.Web.Models.manuais> GetManuaisList()
        {
            return dbcontext.manuais.ToList();
        }



        public IEnumerable<TrocaManuais.Web.Models.manuais> GetManuais()
        {

            return dbcontext.manuais.ToList();

        }

        public TrocaManuais.Web.Models.manuais GetManualByTitulo(string Nome)
        {

            return dbcontext.manuais.Find(Nome);

        }

        public TrocaManuais.Web.Models.manuais GetManualByISBN(int isbn)
        {

            return dbcontext.manuais.Find(isbn);

        }



    }
}
