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
    
    public partial class Escalo
    {
        public Escalo()
        {
            this.AnosEscolares = new HashSet<AnosEscolare>();
        }
    
        public string Escalao { get; set; }
    
        public virtual ICollection<AnosEscolare> AnosEscolares { get; set; }
    }
}
