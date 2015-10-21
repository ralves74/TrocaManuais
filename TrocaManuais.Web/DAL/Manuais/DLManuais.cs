using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;

namespace TrocaManuais.Web.DAL.Manuais
{
    public class DLManuais
    {
         private TrocaManuais.Web.Models.TrocamanuaisEntities dbcontext = new TrocaManuais.Web.Models.TrocamanuaisEntities();

        public DLManuais(TrocaManuais.Web.Models.TrocamanuaisEntities _dbContext)

        {

            this.dbcontext = _dbContext;

        }

        public int GetMaxIdManual()
        {
            int maxid = 0;
            var ttt = new TrocaManuais.Web.Models.TrocamanuaisEntities();
            int maximo = (from c in ttt.manuais select c.idmanual).DefaultIfEmpty(0).Max();
            maxid = ++maximo;
            return maxid;
        }

        public List<TrocaManuais.Web.Models.TodosManuais> manuaisporescalao(string escalao)
        {
            var ttt = new TrocaManuais.Web.Models.TodosManuais();
            List<TrocaManuais.Web.Models.TodosManuais> lista = new List<TrocaManuais.Web.Models.TodosManuais>();
            lista = (from man in dbcontext.TodosManuais where man.Escalao == escalao select man).ToList<TrocaManuais.Web.Models.TodosManuais>();
            return lista;
        }

        public List<TrocaManuais.Web.Models.TodosManuais> manuaispordisciplina(string Disciplina)
        {
            var ttt = new TrocaManuais.Web.Models.TodosManuais();
            List<TrocaManuais.Web.Models.TodosManuais> lista = new List<TrocaManuais.Web.Models.TodosManuais>();
            lista = (from man in dbcontext.TodosManuais where man.disciplina == Disciplina select man).ToList<TrocaManuais.Web.Models.TodosManuais>();
            return lista;
        }

        public List<TrocaManuais.Web.Models.TodosManuais> manuaisporano(string Ano)
        {
            var ttt = new TrocaManuais.Web.Models.TodosManuais();
            List<TrocaManuais.Web.Models.TodosManuais> lista = new List<TrocaManuais.Web.Models.TodosManuais>();
            lista = (from man in dbcontext.TodosManuais where man.ano == Ano select man).ToList<TrocaManuais.Web.Models.TodosManuais>();
            return lista;
        }

        public List<TrocaManuais.Web.Models.TodosManuais> manuaisporDisciplinaAno(string Ano,string Disciplina)
        {
            var ttt = new TrocaManuais.Web.Models.TodosManuais();
            List<TrocaManuais.Web.Models.TodosManuais> lista = new List<TrocaManuais.Web.Models.TodosManuais>();
            lista = (from man in dbcontext.TodosManuais where man.ano == Ano && man.disciplina == Disciplina select man).ToList<TrocaManuais.Web.Models.TodosManuais>();
            return lista;
        }

        public List<TrocaManuais.Web.Models.ManuaisEmStock> GetManualEmStock(string Isbn)
        {
            var ttt = new TrocaManuais.Web.Models.ManuaisEmStock();
            List<TrocaManuais.Web.Models.ManuaisEmStock> lista = new List<TrocaManuais.Web.Models.ManuaisEmStock>();
            lista=(from man in dbcontext.ManuaisEmStock where man.ISBN == Isbn select man).ToList<TrocaManuais.Web.Models.ManuaisEmStock>();
            return lista;
        }
    }
}