using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {

        private C_AnimalesViewModel Convertir(C_Animales animales)
        {
            C_AnimalesViewModel animalesViewModel = new C_AnimalesViewModel
            {
                IdAnimal = animales.IdAnimal,
                nombre = animales.nombre,
                especie = animales.especie,
                raza = animales.raza,
                sexo = animales.sexo,
                otrasSenas = animales.otrasSenas,
                ImagenURL = animales.ImagenURL,
                IdTamano = (int)animales.IdTamano,
                IdTemperamento = (int)animales.IdTemperamento,
                fechaNacimiento = (DateTime)animales.fechaNacimiento,
                padecimientos = animales.padecimientos,

            };
            return animalesViewModel;

        }

            public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnimalesR()
        {
            List<C_Animales> animales;

            using (UnidadDeTrabajo<C_Animales> Unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                animales = Unidad.genericDAL.GetAll().ToList();
            }

            List<C_AnimalesViewModel> animalesVM = new List<C_AnimalesViewModel>();

            C_AnimalesViewModel animalesViewModel;

            foreach (var item in animales)
            {
                animalesViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<C_Tamanos> unidad = new UnidadDeTrabajo<C_Tamanos>(new BDContext()))
                {
                    animalesViewModel.C_Tamanos = unidad.genericDAL.Get(animalesViewModel.IdTamano);
                }

                using (UnidadDeTrabajo<C_Temperamentos> unidad = new UnidadDeTrabajo<C_Temperamentos>(new BDContext()))
                {
                    animalesViewModel.C_Temperamentos = unidad.genericDAL.Get(animalesViewModel.IdTemperamento);
                }

                animalesVM.Add(animalesViewModel);

            }
            return View(animalesVM);
        }


        public ActionResult Report (string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reportes"), "R_Animales.rdlc");

            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            List<C_Animales> animales;

            using (UnidadDeTrabajo<C_Animales> Unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                animales = Unidad.genericDAL.GetAll().ToList();
            }
            ReportDataSource rd = new ReportDataSource("C_AnimalesDS", animales);
            lr.DataSources.Add(rd);
           
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "<OutputFormat>" + id + "</OutputFormat>" +
            "<PageWidth>8.5in</PageWidth>" +
            "<PageHeight>11in</PageHeight>" +
            "<MarginTop>0.5in</MarginTop>" +
            "<MarginLeft>1in</MarginLeft>" +
            "<MarginRight>1in</MarginRight>" +
            "<MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            byte[] renderedBytes = lr.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out string[] streams, out Warning[] warnings);

            return File(renderedBytes, mimeType);

        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult History()
        {
            ViewBag.Message = "Historia de la Organización";

            return View();
        }


        public ActionResult C_ReportesIndex()
        {
            
            return View();
        }
    }
}