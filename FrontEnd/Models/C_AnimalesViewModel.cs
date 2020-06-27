using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class C_AnimalesViewModel
    {

        [Key]
        public int IdAnimal { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "{0} debe tener una longitud menor o igual a 50")]
        [DataType(DataType.MultilineText)]
        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(18)]
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(18, ErrorMessage = "{0} debe tener una longitud menor o igual a 18")]
        [Display(Name = "Especie")]
        [DataType(DataType.MultilineText)]
        public string especie { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(50, ErrorMessage = "{0} debe tener una longitud menor o igual a 50")]
        [Display(Name = "Raza")]
        [DataType(DataType.MultilineText)]

        public string raza { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(1, ErrorMessage = "{0} debe tener una longitud igual a 1 caracter")]
        [Display(Name = "Sexo de Animal")]
        [DataType(DataType.MultilineText)]
        [StringLength(1)]
        public string sexo { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(100, ErrorMessage = "{0} debe tener una longitud menor o igual a 50")]
        [Display(Name = "Otras Señas")]
        [DataType(DataType.MultilineText)]
        public string otrasSenas { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Imagen")]
        public string ImagenURL { get; set; }


        [ForeignKey("C_Tamanos")]
        [Display(Name = "Tamaño")]
        [DataType(DataType.MultilineText)]
        public int? IdTamano { get; set; }
     


        [ForeignKey("C_Temperamentos")]
        [Display(Name = "Temperamento")]
        [DataType(DataType.MultilineText)]
        public int? IdTemperamento { get; set; }
       


        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? fechaNacimiento { get; set; }



        [StringLength(100)]
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(100, ErrorMessage = "{0} debe tener una longitud menor o igual a 50")]
        [Display(Name = "Padecimientos")]
        public string padecimientos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Adopciones> C_Adopciones { get; set; }

        [ForeignKey("IdTamano")]
        public virtual C_Tamanos C_Tamanos { get; set; }

        [ForeignKey("IdTemperamento")]
        public virtual C_Temperamentos C_Temperamentos { get; set; }






    }
}