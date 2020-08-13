using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {
        private BDContext bd = new BDContext();

        private IUserDAL userDAL;

        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Autherize(UserViewModel userModel)
        {

            userDAL = new UserDALImpl();
            string ePass = Encrypt.GetSHA256(userModel.Password);
            var userDetails = userDAL.getUser(userModel.UserName, ePass);


            if (userDetails == null)
            {
                userModel.LoginErrorMessage = "Usuario ó contraseña incorrectos";
                return View("Index", userModel);
            }
            else
            {

                Session["userID"] = userDetails.UserId;
                Session["userName"] = userDetails.UserName;
                var authTicket = new FormsAuthenticationTicket(userDetails.UserName, true, 100000);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                            FormsAuthentication.Encrypt(authTicket));
                Response.Cookies.Add(cookie);
                var name = User.Identity.Name; // line 4
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
            //int userId = (int)Session["userID"];
            Session.Clear();
            Session.Abandon();



            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registrar(string username, string password, string name)
        {

            {

                BackEnd.Entities.Users oUser = new BackEnd.Entities.Users();
                oUser.UserName = username;
                oUser.Password = Encrypt.GetSHA256(password);
                oUser.nombre = name;
                bd.Users.Add(oUser);
                bd.SaveChanges();
               

            }

            return RedirectToAction("Index", "Login");
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public ActionResult RegistrarRoles()
        {
            IUserDAL user = new UserDALImpl();
            UserViewModel usersLi = new UserViewModel();
            usersLi.ListaUsuarios = user.getUsers();
           
            usersLi.ListaRoles = user.getRoles();
            return View(usersLi);
            //return View(usersLi, rolesLi);
        }

        [HttpPost]

        public ActionResult RegistrarRoles(UserViewModel usuario)
        {

            IUserDAL userDAL = new UserDALImpl();

           var data= userDAL.spUsuariosRoles(usuario.UserId,usuario.RoleId);

            usuario.ListaUsuarios = userDAL.getUsers();

            usuario.ListaRoles = userDAL.getRoles();


            return RedirectToAction("RegistrarRoles", "Login");

        }



    }



}