using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Models
{
    public class UserViewModel
    {
        public int UserViewModelId { get; set; }
        [Required(ErrorMessage = "Debe digitar un nombre de usuario!")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        public string nombre { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Debe digitar una contraseña!")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }


        public string LoginErrorMessage { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Debe seleccionar un nombre de usuario!")]
        public int UserId { get; set; }
        public List<SelectListItem> ListaUsuarios { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un rol!")]
        public int RoleId { get; set; }
        [Display(Name = "Rol de Usuario")]
        public string RoleName { get; set; }
        
        public List<SelectListItem> ListaRoles { get; set; }
        public virtual ICollection<Roles> Roles { get; set; }

    }
}