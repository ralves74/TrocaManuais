using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocaManuais.Web;

namespace TrocaManuais.DAL.Manuais
{
    public interface IManuaisRepository
    {
        int GetMaxIdManual();
        void SaveNewManual(TrocaManuais.Web.Models.manuais Manuais);
        IList<TrocaManuais.Web.Models.manuais> GetManuaisList();
        IEnumerable<TrocaManuais.Web.Models.manuais> GetManuais();
        TrocaManuais.Web.Models.manuais GetManualByTitulo(string Nome);
       
        TrocaManuais.Web.Models.manuais GetManualByISBN(int isbn);
       

    }
}
