using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace FrontEnd.Controllers
{
    [Authorize(Roles = "Administrador,Consulta")]
    public class C_AnimalesController : Controller
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



        private C_Animales Convertir(C_AnimalesViewModel animalesViewModel)
        {
            C_Animales animales = new C_Animales
            {
                IdAnimal = animalesViewModel.IdAnimal,
                nombre = animalesViewModel.nombre,
                especie = animalesViewModel.especie,
                raza = animalesViewModel.raza,
                sexo = animalesViewModel.sexo,
                otrasSenas = animalesViewModel.otrasSenas,
                ImagenURL = animalesViewModel.ImagenURL,
                IdTamano = animalesViewModel.IdTamano,
                IdTemperamento = animalesViewModel.IdTemperamento,
                fechaNacimiento = animalesViewModel.fechaNacimiento,
                padecimientos= animalesViewModel.padecimientos,



            };
            return animales;
        }


        // GET: C_Animales
        public ActionResult Index()
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

                using(UnidadDeTrabajo<C_Tamanos> unidad = new UnidadDeTrabajo<C_Tamanos>(new BDContext()))
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


        public ActionResult Create()
        {
            C_AnimalesViewModel animales = new C_AnimalesViewModel();

            using(UnidadDeTrabajo<C_Temperamentos>unidad = new UnidadDeTrabajo<C_Temperamentos>(new BDContext()))
            {
                animales.Temperamentos = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<C_Tamanos> unidad = new UnidadDeTrabajo<C_Tamanos>(new BDContext()))
            {
                animales.Tamanos = unidad.genericDAL.GetAll().ToList();
            }

            return View(animales);
        }




        [HttpPost]
        public ActionResult Create (C_Animales animales, HttpPostedFileBase UploadImage)
        {
            if (UploadImage != null)
            {
                if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" ||
                  UploadImage.ContentType == "image/bmp" || UploadImage.ContentType == "gif" ||
                  UploadImage.ContentType == "image/jpeg")


                {
                    UploadImage.SaveAs(Server.MapPath("/") + "/Cargas/" + UploadImage.FileName);
                    animales.ImagenURL = UploadImage.FileName;

                }
                else return View();
            }
                else return View();

            using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                unidad.genericDAL.Add(animales);
                unidad.Complete();
            }

            return RedirectToAction("Index");

        }




            public ActionResult Edit(int id)
            {

                C_AnimalesViewModel animales;
                C_Animales animalDB;

                using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
                {
                animalDB = unidad.genericDAL.Get(id);
                }

                 animales = this.Convertir(animalDB);

                using (UnidadDeTrabajo<C_Temperamentos> unidad = new UnidadDeTrabajo<C_Temperamentos>(new BDContext()))
                {
                animales.Temperamentos = unidad.genericDAL.GetAll().ToList();
                }

               using (UnidadDeTrabajo<C_Tamanos> unidad = new UnidadDeTrabajo<C_Tamanos>(new BDContext()))
               {
                animales.Tamanos = unidad.genericDAL.GetAll().ToList();
               }

              return View(animales);


            }


        [HttpPost]
       public ActionResult Edit(C_Animales animales, HttpPostedFileBase UploadImage)
        {
           
                if (UploadImage != null)
                {

                    if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" ||
                        UploadImage.ContentType == "image/bmp" || UploadImage.ContentType == "gif" ||
                        UploadImage.ContentType == "image/jpeg")


                    {
                        UploadImage.SaveAs(Server.MapPath("/") + "/Cargas/" + UploadImage.FileName);
                        animales.ImagenURL = UploadImage.FileName;

                    }

                    else
                        return View();
                }

                else return View();

                using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
                {

                unidad.genericDAL.Update(animales);
                unidad.Complete();

                }

               return RedirectToAction("Index");
             
       }

        public ActionResult Details(int id)
        {

            C_Animales animales;

            using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                animales = unidad.genericDAL.Get(id); 
            }

            C_AnimalesViewModel animal = this.Convertir(animales);

            using (UnidadDeTrabajo<C_Temperamentos> unidad = new UnidadDeTrabajo<C_Temperamentos>(new BDContext()))
            {
                animal.C_Temperamentos = unidad.genericDAL.Get(animal.IdTemperamento);
            }

            using (UnidadDeTrabajo<C_Tamanos> unidad = new UnidadDeTrabajo<C_Tamanos>(new BDContext()))
            {
                animal.C_Tamanos = unidad.genericDAL.Get(animal.IdTamano);
            }

            return View(animal);
        }



        public ActionResult Delete(int id)
        {
            C_Animales animales;

            using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                animales = unidad.genericDAL.Get(id);
            }

            C_AnimalesViewModel animal = this.Convertir(animales);

            using (UnidadDeTrabajo<C_Temperamentos> unidad = new UnidadDeTrabajo<C_Temperamentos>(new BDContext()))
            {
                animal.C_Temperamentos = unidad.genericDAL.Get(animal.IdTemperamento);
            }

            using (UnidadDeTrabajo<C_Tamanos> unidad = new UnidadDeTrabajo<C_Tamanos>(new BDContext()))
            {
                animal.C_Tamanos = unidad.genericDAL.Get(animal.IdTamano);
            }

            return View(animal);
        }


        [HttpPost]
        public ActionResult Delete(C_AnimalesViewModel animalView)
        {
            using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(animalView));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }




    }

}
