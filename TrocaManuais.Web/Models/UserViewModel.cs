using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrocaManuais.Web.Models
{
    public class UserViewModel
    {
        [Key]
        public string Nick { get; set; }
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Palavra-Chave")]
        public string password { get; set; }
        public string nome { get; set; }
        public Nullable<bool> BLivro { get; set; }
        public Nullable<int> cp4 { get; set; }
        public Nullable<int> cp3 { get; set; }

    }
}