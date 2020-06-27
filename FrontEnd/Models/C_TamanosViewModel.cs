using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class C_TamanosViewModel
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public C_TamanosViewModel()
        {
            C_Animales = new HashSet<C_Animales>();
        }

        [Key]

        public int IdTamanos { get; set; }

        [StringLength(20)]

        [Display(Name = "Tamaño")]

        public string tamanos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Animales> C_Animales { get; set; }
    }
}
