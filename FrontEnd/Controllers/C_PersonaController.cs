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
    public class C_PersonaController : Controller
    {

        private C_PersonaViewModel Convertir(C_Persona personas)
        {
            C_PersonaViewModel personaViewModel = new C_PersonaViewModel
            {
                IdPersona = personas.IdPersona,
                IdDistrito = (int)personas.IdDistrito,
                IdProvincia = (int)personas.IdProvincia,
                IdCanton = (int)personas.IdCanton,
                nombrePersona = personas.nombrePersona,
                primerApellido = personas.primerApellido,
                segundoApellido = personas.segundoApellido,
                cedula=personas.cedula,
                correo=personas.correo,
                sexo = personas.sexo,
                telefono = personas.telefono,
                direccion= personas.direccion,
                estadoCivil= personas.estadoCivil,
                fechaNacimiento= personas.fechaNacimiento,


                
            };
            return personaViewModel;
        }



        private C_Persona Convertir(C_PersonaViewModel personaViewModel)
        {
            C_Persona personas = new C_Persona
            {
                IdPersona = personaViewModel.IdPersona,
                IdDistrito = (int)personaViewModel.IdDistrito,
                IdProvincia = (int)personaViewModel.IdProvincia,
                IdCanton = (int)personaViewModel.IdCanton,
                nombrePersona = personaViewModel.nombrePersona,
                primerApellido = personaViewModel.primerApellido,
                segundoApellido = personaViewModel.segundoApellido,
                cedula = personaViewModel.cedula,
                correo = personaViewModel.correo,
                sexo = personaViewModel.sexo,
                telefono = personaViewModel.telefono,
                direccion = personaViewModel.direccion,
                estadoCivil = personaViewModel.estadoCivil,
                fechaNacimiento = personaViewModel.fechaNacimiento,

            };
            return personas;
        }


        // GET: C_Personas
        public ActionResult Index()
        {

            List<C_Persona> personas;

            using (UnidadDeTrabajo<C_Persona> Unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                personas = Unidad.genericDAL.GetAll().ToList();
            }

            List<C_PersonaViewModel> personasVM = new List<C_PersonaViewModel>();

            C_PersonaViewModel personasViewModel;

            foreach (var item in personas)
            {
                personasViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<C_Distrito> unidad = new UnidadDeTrabajo<C_Distrito>(new BDContext()))
                {
                    personasViewModel.C_Distrito = unidad.genericDAL.Get(personasViewModel.IdDistrito);
                }

                using (UnidadDeTrabajo<C_Provincia> unidad = new UnidadDeTrabajo<C_Provincia>(new BDContext()))
                {
                    personasViewModel.C_Provincia = unidad.genericDAL.Get(personasViewModel.IdProvincia);
                }

                using (UnidadDeTrabajo<C_Canton> unidad = new UnidadDeTrabajo<C_Canton>(new BDContext()))
                {
                    personasViewModel.C_Canton = unidad.genericDAL.Get(personasViewModel.IdCanton);
                }


                personasVM.Add(personasViewModel);

            }
            return View(personasVM);
        }



        public ActionResult Create()
        {
            C_PersonaViewModel personas = new C_PersonaViewModel();

           
            using (UnidadDeTrabajo<C_Distrito> unidad = new UnidadDeTrabajo<C_Distrito>(new BDContext()))
            {
                personas.Distritos = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<C_Provincia> unidad = new UnidadDeTrabajo<C_Provincia>(new BDContext()))
            {
                personas.Provincias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<C_Canton> unidad = new UnidadDeTrabajo<C_Canton>(new BDContext()))
            {
                personas.Cantons = unidad.genericDAL.GetAll().ToList();
            }



            return View(personas);
        }


        [HttpPost]
        public ActionResult Create(C_Persona personas)
        {
            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                unidad.genericDAL.Add(personas);
                unidad.Complete();
            }

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {

            C_PersonaViewModel personas;
            C_Persona personasDB;

            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                personasDB = unidad.genericDAL.Get(id);
            }

            personas = this.Convertir(personasDB);

            using (UnidadDeTrabajo<C_Distrito> unidad = new UnidadDeTrabajo<C_Distrito>(new BDContext()))
            {
                personas.Distritos = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<C_Provincia> unidad = new UnidadDeTrabajo<C_Provincia>(new BDContext()))
            {
                personas.Provincias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<C_Canton> unidad = new UnidadDeTrabajo<C_Canton>(new BDContext()))
            {
                personas.Cantons = unidad.genericDAL.GetAll().ToList();
            }


            return View(personas);


        }


        [HttpPost]
        public ActionResult Edit(C_Persona personas)
        {

            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {

                unidad.genericDAL.Update(personas);
                unidad.Complete();

            }

            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {

            C_Persona personas;

            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                personas = unidad.genericDAL.Get(id);
            }

            C_PersonaViewModel persona = this.Convertir(personas);

            using (UnidadDeTrabajo<C_Distrito> unidad = new UnidadDeTrabajo<C_Distrito>(new BDContext()))
            {
                persona.C_Distrito = unidad.genericDAL.Get(persona.IdDistrito);
            }

            using (UnidadDeTrabajo<C_Provincia> unidad = new UnidadDeTrabajo<C_Provincia>(new BDContext()))
            {
                persona.C_Provincia = unidad.genericDAL.Get(persona.IdProvincia);
            }

            using (UnidadDeTrabajo<C_Canton> unidad = new UnidadDeTrabajo<C_Canton>(new BDContext()))
            {
                persona.C_Canton = unidad.genericDAL.Get(persona.IdCanton);
            }

            return View(persona);
        }



        public ActionResult Delete(int id)
        {
            C_Persona personas;

            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                personas = unidad.genericDAL.Get(id);
            }


            C_PersonaViewModel persona = this.Convertir(personas);


            using (UnidadDeTrabajo<C_Distrito> unidad = new UnidadDeTrabajo<C_Distrito>(new BDContext()))
            {
                persona.C_Distrito = unidad.genericDAL.Get(persona.IdDistrito);
            }

            using (UnidadDeTrabajo<C_Provincia> unidad = new UnidadDeTrabajo<C_Provincia>(new BDContext()))
            {
                persona.C_Provincia = unidad.genericDAL.Get(persona.IdProvincia);
            }

            using (UnidadDeTrabajo<C_Canton> unidad = new UnidadDeTrabajo<C_Canton>(new BDContext()))
            {
                persona.C_Canton = unidad.genericDAL.Get(persona.IdCanton);
            }

            return View(persona);
        }


        [HttpPost]
        public ActionResult Delete(C_PersonaViewModel personasView)
        {
            using (UnidadDeTrabajo<C_Persona> unidad = new UnidadDeTrabajo<C_Persona>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(personasView));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}