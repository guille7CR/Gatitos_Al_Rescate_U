using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class C_CasaCunaViewModel
    {
        [Key]
        public int IdCasaCuna { get; set; }

        [Display(Name = "Persona")]
        [Required(ErrorMessage = "*{0} es requerido*")]
        public int IdPersona { get; set; }
        public IEnumerable<C_Persona> Personas { get; set; }
        public C_Persona C_Persona { get; set; }

        [Required(ErrorMessage = "*{0} es requerido*")]
        [MaxLength(50, ErrorMessage = "*{0} debe tener una longitud menor o igual a 50*")]
        [Display(Name = "Metros Cuadrados")]
        public string Metros { get; set; }

        [Display(Name = "Propiedad Cercada?")]
        [Required(ErrorMessage = "*{0} es requerido*")]
        public bool PropiedadCercada { get; set; }

        [Display(Name = "Otras Mascotas")]
        [Required(ErrorMessage = "*{0} es requerido*")]
        public int OtrasMascotas { get; set; }

        [Display(Name = "Capacidad Disponible")]
        [Required(ErrorMessage = "*{0} es requerido*")]
        public int CapacidadDisponible { get; set; }

        [Required(ErrorMessage = "*{0} es requerido*")]
        [MaxLength(250, ErrorMessage = "*{0} debe tener una longitud menor o igual a 250*")]
        [Display(Name = "Descripción de la Propiedad")]
        public string DescripcionPropiedad { get; set; }

        
    }
}


