using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class C_AdopcionesController : Controller
    {
        private C_AdopcionesViewModel Convertir(C_Adopciones adopciones)
        {
            C_AdopcionesViewModel adopcionesViewModel = new C_AdopcionesViewModel
            {

                IdAdopcion = adopciones.IdAdopcion,
                IdAnimal = (int)adopciones.IdAnimal,
                IdPersona = (int)adopciones.IdPersona,
                FechaAdopcion = adopciones.FechaAdopcion
            };
            return adopcionesViewModel;
        }



        private C_Adopciones Convertir(C_AdopcionesViewModel adopcionesViewModel)
        {
            C_Adopciones adopciones = new C_Adopciones
            {

                IdAdopcion = adopcionesViewModel.IdAdopcion,
                IdAnimal = (int)adopcionesViewModel.IdAnimal,
                IdPersona = (int)adopcionesViewModel.IdPersona,
                FechaAdopcion = adopcionesViewModel.FechaAdopcion


            };
            return adopciones;
        }

        public ActionResult Index()
        {

            List<C_Adopciones> adopciones;

            using (UnidadDeTrabajo<C_Adopciones> Unidad = new UnidadDeTrabajo<C_Adopciones>(new BDContext()))
            {
                adopciones = Unidad.genericDAL.GetAll().ToList();
            }

            List<C_AdopcionesViewModel> adopcionesVM = new List<C_AdopcionesViewModel>();

            C_AdopcionesViewModel adopcionesViewModel;

            foreach (var item in adopciones)
            {
                adopcionesViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
                {
                    adopcionesViewModel.C_Animales = unidad.genericDAL.Get(adopcionesViewModel.IdAnimal);
                }

                using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
                {
                    adopcionesViewModel.C_Persona = unidad.genericDAL.Get(adopcionesViewModel.IdPersona);
                }

                adopcionesVM.Add(adopcionesViewModel);

            }
            return View(adopcionesVM);
        }



        public ActionResult Create()
        {
            C_AdopcionesViewModel adopciones = new C_AdopcionesViewModel();


            using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                adopciones.Animales = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                adopciones.Personas = unidad.genericDAL.GetAll().ToList();
            }
            return View(adopciones);
        }


        [HttpPost]
        public ActionResult Create(C_Adopciones adopciones)
        {
            using (UnidadDeTrabajo<C_Adopciones> unidad = new UnidadDeTrabajo<C_Adopciones>(new BDContext()))
            {
                unidad.genericDAL.Add(adopciones);
                unidad.Complete();
            }

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {

            C_AdopcionesViewModel adopciones;
            C_Adopciones adopcionesDB;

            using (UnidadDeTrabajo < C_Adopciones> unidad = new UnidadDeTrabajo<C_Adopciones>(new BDContext()))
            {
                adopcionesDB = unidad.genericDAL.Get(id);
            }

            adopciones = this.Convertir(adopcionesDB);

            using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                adopciones.Animales = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                adopciones.Personas = unidad.genericDAL.GetAll().ToList();
            }

            return View(adopciones);

        }


        [HttpPost]
        public ActionResult Edit(C_Adopciones adopciones)
        {

            using (UnidadDeTrabajo<C_Adopciones> unidad = new UnidadDeTrabajo<C_Adopciones>(new BDContext()))
            {

                unidad.genericDAL.Update(adopciones);
                unidad.Complete();

            }

            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {

            C_Adopciones adopciones;

            using (UnidadDeTrabajo<C_Adopciones> unidad = new UnidadDeTrabajo<C_Adopciones>(new BDContext()))
            {
                adopciones = unidad.genericDAL.Get(id);
            }

            C_AdopcionesViewModel adopcion = this.Convertir(adopciones);

            using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                adopcion.C_Animales = unidad.genericDAL.Get(adopcion.IdAnimal);
            }

            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                adopcion.C_Persona = unidad.genericDAL.Get(adopcion.IdPersona);
            }

            return View(adopcion);
        }



        public ActionResult Delete(int id)
        {
            C_Adopciones adopciones;

            using (UnidadDeTrabajo<C_Adopciones> unidad = new UnidadDeTrabajo<C_Adopciones>(new BDContext()))
            {
                adopciones = unidad.genericDAL.Get(id);
            }


            C_AdopcionesViewModel adopcion  = this.Convertir(adopciones);


            using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                adopcion.C_Animales = unidad.genericDAL.Get(adopcion.IdAnimal);
            }

            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                adopcion.C_Persona = unidad.genericDAL.Get(adopcion.IdPersona);
            }

            return View(adopcion);
        }


        [HttpPost]
        public ActionResult Delete(C_AdopcionesViewModel adopcionesView)
        {
            using (UnidadDeTrabajo<C_Adopciones> unidad = new UnidadDeTrabajo<C_Adopciones>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(adopcionesView));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }







    }
}