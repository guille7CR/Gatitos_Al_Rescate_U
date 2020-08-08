using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = "Administrador,Consulta")]
    public class EnviaCorreoController : Controller
    {
        // GET: EnviaCorreo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EnviarCorreo()
        {
            return View();
        }


        [HttpPost]
      public ActionResult EnviarCorreo(String contactoCorreo, String contactoNombre, String asunto, String mensaje, HttpPostedFileBase fichero)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("gramirez7CR@gmail.com");
                correo.To.Add("gramirez7CR@gmail.com");
                correo.Subject = asunto;
                String ruta = Server.MapPath("");
                fichero.SaveAs(Server.MapPath("/") + "/Cargas/" + fichero.FileName);
                Attachment adjunto = new Attachment(Server.MapPath("/") + "/Cargas/" + fichero.FileName);
                correo.Attachments.Add(adjunto);

                correo.Body = "CORREO : " + contactoCorreo+ "<br/>" + "<br/>" +
                              "NOMBRE : " + contactoNombre + "<br/>" + "<br/>" +
                              "PARA : " +correo.To+ "<br/>" + "<br/>" +
                              "MENSAJE : " + mensaje +"<br/>"+ "<br/>" +
                              "IMAGEN : " +"<br/>" + "<br/>" ;

                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

               

                //SMTP Client

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("gramirez7CR@gmail.com", "scikitlearn7CR");
                
                smtp.Send(correo);
                ViewBag.Mensaje = "Se ha enviado el correo";
               }

            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
      }

    }
}