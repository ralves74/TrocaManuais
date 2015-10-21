using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrocaManuais.Web.ViewModels
{
    public class CreateManualViewModel
    {
        public int idmanual { get; set; }
        public string Editora { get; set; }
        public string disciplina { get; set; }
        public string ISBN { get; set; }
        public string titulo { get; set; }
        public string Autores { get; set; }
        
        [DataType(DataType.Upload)]
        HttpPostedFileBase ImageUpload { get; set; }
        public Nullable<int> idAEscola { get; set; }
        public Nullable<bool> Inactivo { get; set; }

        public string  AnosEscolares { get; set; }
        public string  Disciplinas { get; set; }
        public string  Editoras { get; set; }
        
    }
}