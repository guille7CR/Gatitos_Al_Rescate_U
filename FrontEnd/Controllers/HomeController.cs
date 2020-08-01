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



        public ActionResult ReportePersonas()
        {

            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                ShowExportControls = true,
                ShowParameterPrompts = true,
                ShowPageNavigationControls = true,
                ShowRefreshButton = true,
                ShowPrintButton = true,
                SizeToReportContent = true,
                AsyncRendering = false,
            };
            string rutaReporte = "~/Reportes/R_Personas.rdlc";
            ///construir la ruta física
            string rutaServidor = Server.MapPath(rutaReporte);
            reportViewer.LocalReport.ReportPath = rutaServidor;
            //reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\ReportCategories.rdlc";
            var infoFuenteDatos = reportViewer.LocalReport.GetDataSourceNames();
            reportViewer.LocalReport.DataSources.Clear();

            List<sp_ReportePersonas_Result> datosReporte;
            using (BDContext context = new BDContext())
            {
                datosReporte = context.sp_ReportePersonas().ToList();
            }
            ReportDataSource fuenteDatos = new ReportDataSource();
            fuenteDatos.Name = infoFuenteDatos[0];
            fuenteDatos.Value = datosReporte;
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("sp_ReportePersonas", datosReporte));

            reportViewer.LocalReport.Refresh();
            ViewBag.ReportViewer = reportViewer;


            return View();

        }

        public ActionResult ReporteCasaCuna()
        {
            ICasaCunaDAL casa = new CasaCunaDALImpl();


            C_ProvinciaViewModel prov = new C_ProvinciaViewModel();
            prov.ListaProvincia = casa.getProvincias();


            return View(prov);
        }


        [HttpPost]
        public ActionResult ReporteCasaCuna(C_ProvinciaViewModel provincia)
        {

            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                ShowExportControls = true,
                ShowParameterPrompts = true,
                ShowPageNavigationControls = true,
                ShowRefreshButton = true,
                ShowPrintButton = true,
                SizeToReportContent = true,
                AsyncRendering = false,
            };
            string rutaReporte = "~/Reportes/R_CasaCuna.rdlc";
            ///construir la ruta física
            string rutaServidor = Server.MapPath(rutaReporte);
            reportViewer.LocalReport.ReportPath = rutaServidor;
            //reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\ReportCategories.rdlc";
            var infoFuenteDatos = reportViewer.LocalReport.GetDataSourceNames();
            reportViewer.LocalReport.DataSources.Clear();
            /**/
            List<sp_ReporteCasaCuna_Result> datosReporte;
            ICasaCunaDAL casacunaDAL = new CasaCunaDALImpl();
            datosReporte = casacunaDAL.datosReporte(provincia.idProvincia);

            /**/

            ReportDataSource fuenteDatos = new ReportDataSource();
            fuenteDatos.Name = infoFuenteDatos[0];
            fuenteDatos.Value = datosReporte;
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("sp_ReporteCasaCuna", datosReporte));

            reportViewer.LocalReport.Refresh();
            ViewBag.ReportViewer = reportViewer;


            return View("ReportesCasaCuna");

        }

        public ActionResult ReporteAdopciones()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ReporteAdopciones(C_CedulaViewModel cedula)
        {

            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                ShowExportControls = true,
                ShowParameterPrompts = true,
                ShowPageNavigationControls = true,
                ShowRefreshButton = true,
                ShowPrintButton = true,
                SizeToReportContent = true,
                AsyncRendering = false,
            };
            string rutaReporte = "~/Reportes/R_Adopciones.rdlc";
            ///construir la ruta física
            string rutaServidor = Server.MapPath(rutaReporte);
            reportViewer.LocalReport.ReportPath = rutaServidor;
            //reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\ReportCategories.rdlc";
            var infoFuenteDatos = reportViewer.LocalReport.GetDataSourceNames();
            reportViewer.LocalReport.DataSources.Clear();
            /**/
            List<sp_ReporteAdopciones_Result> datosReporte;
            ICedulaDAL orderDAL = new CedulaDALImpl();
            datosReporte = orderDAL.datosReporte(cedula.IdCedula);

            /**/

            ReportDataSource fuenteDatos = new ReportDataSource();
            fuenteDatos.Name = infoFuenteDatos[0];
            fuenteDatos.Value = datosReporte;
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("sp_ReporteAdopciones", datosReporte));

            reportViewer.LocalReport.Refresh();
            ViewBag.ReportViewer = reportViewer;


            return View("ReportesAdopciones");

        }

    }
}