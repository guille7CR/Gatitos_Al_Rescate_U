using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Models
{
    public class C_ProvinciaViewModel
    {
        public int idProvincia { get; set; }
        public List<SelectListItem> ListaProvincia { get; set; }
    }
}