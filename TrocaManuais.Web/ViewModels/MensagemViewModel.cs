using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrocaManuais.Web.ViewModels
{
    public class MensagemViewModel
    {
        public string manual { get; set; }
        public string NickRemetente { get; set; }

        public string NickDestinatario { get; set; }
        public string Mensagem { get; set; }
    }
}