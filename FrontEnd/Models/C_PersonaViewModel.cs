using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class C_PersonaViewModel
    {
        [Key]
        public int IdPersona { get; set; }


        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "*{0} es requerido*")]
        public int IdDistrito { get; set; }
        public IEnumerable<C_Distrito> Distritos { get; set; }
        public C_Distrito C_Distrito { get; set; }


        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "*{0} es requerido*")]
        public int IdProvincia { get; set; }
        public IEnumerable<C_Provincia> Provincias { get; set; }
        public C_Provincia C_Provincia { get; set; }

        [Display(Name = "Cantón")]
        [Required(ErrorMessage = "*{0} es requerido*")]
        public int IdCanton { get; set; }
        public IEnumerable<C_Canton> Cantons { get; set; }
        public C_Canton C_Canton { get; set; }

        [Required(ErrorMessage = "*{0} es requerido*")]
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "*{0} debe tener una longitud menor o igual a 50*")]
        [StringLength(50)]
        public string nombrePersona { get; set; }

        [Required(ErrorMessage = "*{0} es requerido*")]
        [Display(Name = "Primer Apellido")]
        [MaxLength(50, ErrorMessage = "*{0} debe tener una longitud menor o igual a 50*")]
        [StringLength(50)]
        public string primerApellido { get; set; }

        [Required(ErrorMessage = "*{0} es requerido*")]
        [Display(Name = "Segundo Apellido")]
        [MaxLength(50, ErrorMessage = "*{0} debe tener una longitud menor o igual a 50*")]
        [StringLength(50)]
        public string segundoApellido { get; set; }

        [Required(ErrorMessage = "*{0} es requerido*")]
        [Display(Name = "Cédula")]
        [MaxLength(12, ErrorMessage = "*{0} debe tener una longitud menor o igual a 12*")]
        [StringLength(12)]
        public string cedula { get; set; }

        [Required(ErrorMessage = "*{0} es requerido*")]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50, ErrorMessage = "*{0} debe tener una longitud menor o igual a 50*")]
        [StringLength(50)]
        public string correo { get; set; }

        [Required(ErrorMessage = "*{0} es requerido*")]
        [Display(Name = "Género")]
        [MaxLength(12, ErrorMessage = "*{0} debe tener una longitud menor o igual a 12*")]
        [StringLength(12)]
        public string sexo { get; set; }

        [Required(ErrorMessage = "*{0} es requerido*")]
        [Display(Name = "Teléfono")]
        [MaxLength(12, ErrorMessage = "*{0} debe tener una longitud menor o igual a 12*")]
        [StringLength(12)]
        public string telefono { get; set; }

        [Required(ErrorMessage = "*{0} es requerido*")]
        [Display(Name = "Dirección Exacta")]
        [MaxLength(250, ErrorMessage = "*{0} debe tener una longitud menor o igual a 250*")]
        [StringLength(250)]
        public string direccion { get; set; }

        [Required(ErrorMessage = "*{0} es requerido*")]
        [Display(Name = "Estado Civíl")]
        [MaxLength(20, ErrorMessage = "*{0} debe tener una longitud menor o igual a 12*")]
        [StringLength(20)]
        public string estadoCivil { get; set; }


        [DataType(DataType.Date)]
        [Required(ErrorMessage = "*{0} es requerido*")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? fechaNacimiento { get; set; }

    
        public  ICollection<C_Adopciones> C_Adopciones { get; set; }
        public ICollection<C_CasaCuna> C_CasaCuna { get; set; }
        
    }
}