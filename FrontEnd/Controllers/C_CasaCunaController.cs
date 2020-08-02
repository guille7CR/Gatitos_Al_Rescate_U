using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class C_CasaCunaController : Controller
    {

        private C_CasaCunaViewModel Convertir(C_CasaCuna casaCunas)
        {
            C_CasaCunaViewModel casaCunaViewModel = new C_CasaCunaViewModel
            {

                IdCasaCuna = casaCunas.IdCasaCuna,
                IdPersona = (int)casaCunas.IdPersona,
                Metros = casaCunas.Metros,
                PropiedadCercada = (bool)casaCunas.PropiedadCercada,
                OtrasMascotas = (int)casaCunas.OtrasMascotas,
                CapacidadDisponible =(int)casaCunas.CapacidadDisponible,
                DescripcionPropiedad = casaCunas.DescripcionPropiedad

            };
            return casaCunaViewModel;
        }



        private C_CasaCuna Convertir(C_CasaCunaViewModel casaCunaViewModel)
        {
            C_CasaCuna casaCunas = new C_CasaCuna
            {
                IdCasaCuna = casaCunaViewModel.IdCasaCuna,
                IdPersona = (int)casaCunaViewModel.IdPersona,
                Metros = casaCunaViewModel.Metros,
                PropiedadCercada = (bool)casaCunaViewModel.PropiedadCercada,
                OtrasMascotas = (int)casaCunaViewModel.OtrasMascotas,
                CapacidadDisponible= (int)casaCunaViewModel.CapacidadDisponible,
                DescripcionPropiedad = casaCunaViewModel.DescripcionPropiedad



            };
            return casaCunas;
        }


        // GET: C_Animales
        public ActionResult Index()
        {

            List<C_CasaCuna> casaCunas;

            using (UnidadDeTrabajo<C_CasaCuna> Unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {
                casaCunas = Unidad.genericDAL.GetAll().ToList();
            }

            List<C_CasaCunaViewModel> casaCunasVM = new List<C_CasaCunaViewModel>();

            C_CasaCunaViewModel casaCunasViewModel;

            foreach (var item in casaCunas)
            {
                casaCunasViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
                {
                    casaCunasViewModel.C_Persona = unidad.genericDAL.Get(casaCunasViewModel.IdPersona);
                }


                casaCunasVM.Add(casaCunasViewModel);

            }
            return View(casaCunasVM);
        }



        public ActionResult Create()
        {
            C_CasaCunaViewModel casaCunas = new C_CasaCunaViewModel();

            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                casaCunas.Personas = unidad.genericDAL.GetAll().ToList();
            }


            return View(casaCunas);
        }


        [HttpPost]
        public ActionResult Create(C_CasaCuna casaCunas)
        {
            using (UnidadDeTrabajo<C_CasaCuna> unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {
                unidad.genericDAL.Add(casaCunas);
                unidad.Complete();
            }

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {

            C_CasaCunaViewModel casaCunas;
            C_CasaCuna  casaCunasDB;

            using (UnidadDeTrabajo<C_CasaCuna> unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {
                casaCunasDB = unidad.genericDAL.Get(id);
            }

            casaCunas = this.Convertir(casaCunasDB);

            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                casaCunas.Personas = unidad.genericDAL.GetAll().ToList();
            }

            
            return View(casaCunas);


        }


        [HttpPost]
        public ActionResult Edit(C_CasaCuna casaCunas)
        {

            using (UnidadDeTrabajo<C_CasaCuna> unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {

                unidad.genericDAL.Update(casaCunas);
                unidad.Complete();

            }

            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {

            C_CasaCuna casaCunas;

            using (UnidadDeTrabajo<C_CasaCuna> unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {
                casaCunas = unidad.genericDAL.Get(id);
            }

            C_CasaCunaViewModel casaCuna = this.Convertir(casaCunas);

            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                casaCuna.C_Persona= unidad.genericDAL.Get(casaCuna.IdPersona);
            }

            return View(casaCuna);
        }



        public ActionResult Delete(int id)
        {
            C_CasaCuna casaCunas;

            using (UnidadDeTrabajo<C_CasaCuna> unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {
                casaCunas = unidad.genericDAL.Get(id);
            }

            C_CasaCunaViewModel casaCuna = this.Convertir(casaCunas);

            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                casaCuna.C_Persona= unidad.genericDAL.Get(casaCuna.IdPersona);
            }

            return View(casaCuna);
        }


        [HttpPost]
        public ActionResult Delete(C_CasaCunaViewModel casaCunasView)
        {
            using (UnidadDeTrabajo<C_CasaCuna> unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(casaCunasView));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

    }
}