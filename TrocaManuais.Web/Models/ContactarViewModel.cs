using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrocaManuais.Web.Models
{
    public class ContactarViewModel
    {
        [Key]
        public int idmanual { get; set; }
        public string Editora { get; set; }
        public string disciplina { get; set; }
        public string ISBN { get; set; }
        public string titulo { get; set; }
        public string Autores { get; set; }
        public string foto { get; set; }

        public string NickName { get; set; }

    }
}