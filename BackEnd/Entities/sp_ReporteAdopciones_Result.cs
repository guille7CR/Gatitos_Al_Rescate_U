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
    
    public partial class sp_ReporteAdopciones_Result
    {
        public string cedula { get; set; }
        public string nombrePersona { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string nombre { get; set; }
        public string sexo { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public Nullable<System.DateTime> FechaAdopcion { get; set; }
    }
}