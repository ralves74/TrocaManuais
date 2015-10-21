using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrocaManuais.Web.Models
{
    public class EnvioMensagemViewModel
    {
        [Key]
        public int idMR { get; set; }
        public string Nick { get; set; }
        public string NickName { get; set; }
        public string Isbn { get; set;}
        public string titulo { get; set; }
        public string mensagem { get; set; }
    }
}