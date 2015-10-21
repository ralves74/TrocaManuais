using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrocaManuais.Web.Models
{
    public class ManuaisPorEscalaoViewModels
    {
        [Key]
        public int idmanual { get; set; }
        public string isbn { get; set; }
        public string titulo { get; set; }
        public string disciplina { get; set; }
        public string editora { get; set; }
        public string ano { get; set; }


    }
}