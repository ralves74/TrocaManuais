using System.ComponentModel.DataAnnotations;

namespace TrocaManuais.Web.Models
{
    public class ManuaisViewModels
    {

        public int idmanual { get; set; }
        public string Editora { get; set; }
        public string disciplina { get; set; }
        public string ISBN { get; set; }
        public string titulo { get; set; }
        public string Autores { get; set; }
        public string foto { get; set; }

        public virtual AnosEscolares AnosEscolares { get; set; }
       
       

    }
}