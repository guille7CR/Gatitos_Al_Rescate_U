//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class C_Adopciones
    {
        public int IdAdopcion { get; set; }
        public Nullable<int> IdPersona { get; set; }
        public Nullable<int> IdAnimal { get; set; }
        public Nullable<System.DateTime> FechaAdopcion { get; set; }
    
        public virtual C_Animales C_Animales { get; set; }
        public virtual C_Persona C_Persona { get; set; }
    }
}
