using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class C_AdopcionesViewModel
    {
        [Key]
        public int IdAdopcion { get; set; }

        [Display(Name = "Persona")]
        [Required(ErrorMessage = "*{0} es requerido*")]
        public int IdPersona { get; set; }
        public IEnumerable<C_Persona> Personas  { get; set; }
        public C_Persona C_Persona { get; set; }


        [DataType(DataType.Date)]
        [Required(ErrorMessage = "*{0} es requerido*")]
        [Display(Name = "Fecha de la Adopción")]
        public DateTime? FechaAdopcion { get; set; }

       

        [Display(Name = "Animal")]
        [Required(ErrorMessage = "*{0} es requerido*")]
        public int IdAnimal { get; set; }
        public IEnumerable<C_Animales> Animales { get; set; }
        public  C_Animales C_Animales { get; set; }
        
    }
}