using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class C_CedulaViewModel
    {
        [Required(ErrorMessage = "*{0} es requerido*")]
        public string IdCedula { get; set; }
    }
}