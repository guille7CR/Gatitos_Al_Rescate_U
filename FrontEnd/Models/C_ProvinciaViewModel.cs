﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Models
{
    public class C_ProvinciaViewModel
    {
        [Required(ErrorMessage = "*{0} es requerido*")]
        public int idProvincia { get; set; }
        public List<SelectListItem> ListaProvincia { get; set; }
    }
}