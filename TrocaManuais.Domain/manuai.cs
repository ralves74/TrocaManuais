//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrocaManuais.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class manuai
    {
        public manuai()
        {
            this.mestabs = new HashSet<mestab>();
            this.stocks = new HashSet<stock>();
        }
    
        public string Editora { get; set; }
        public string disciplina { get; set; }
        public int idmanual { get; set; }
        public string ISBN { get; set; }
        public string titulo { get; set; }
        public string Autores { get; set; }
        public Nullable<int> idAescolar { get; set; }
        public byte[] foto { get; set; }
        public Nullable<int> idAEscola { get; set; }
        public Nullable<bool> Inactivo { get; set; }
    
        public virtual AnosEscolare AnosEscolare { get; set; }
        public virtual Disciplina Disciplina1 { get; set; }
        public virtual Editora Editora1 { get; set; }
        public virtual ICollection<mestab> mestabs { get; set; }
        public virtual ICollection<stock> stocks { get; set; }
    }
}
