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
    public class C_AnimalesController : Controller
    {

        private BDContext db = new BDContext();

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
                IdTamano = animales.IdTamano,
                IdTemperamento = animales.IdTemperamento,
                fechaNacimiento = animales.fechaNacimiento


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
                fechaNacimiento = animalesViewModel.fechaNacimiento



            };
            return animales;
        }

        public ActionResult Index()
        {
            //var animales = db.C_Animales.Include(c => c.).Include(c => c.IdTemperamento);
            
            List<C_Animales> animales;
            
            
            using (UnidadDeTrabajo<C_Animales> Unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                animales = Unidad.genericDAL.GetAll().ToList();
            }
            List<C_AnimalesViewModel> lista = new List<C_AnimalesViewModel>();
            
            foreach (var item in animales)
                  {
                       lista.Add(this.Convertir(item));
                   }

                   return View(lista);
                
           
        }


        //// GET: C_Animales
        //public  ActionResult Index()
        //{

        //    //var animales = db.C_Animales.Include(c => c.C_Tamanos.tamanos).Include(c => c.C_Temperamentos.temperamento);
        //    //return View(await animales.ToListAsync());



        //    //return View(await animales.ToListAsync());
        //    //var lista = await c_Animales.ToListAsync();

        //    //return View(lista);

        //    List<C_Animales> animales;

        //    using (UnidadDeTrabajo<C_Animales> Unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
        //    {
        //        animales = Unidad.genericDAL.GetAll().ToList();
        //    }

        //    List<C_AnimalesViewModel> lista = new List<C_AnimalesViewModel>();

        //    foreach (var item in animales)
        //    {
        //        lista.Add(this.Convertir(item));
        //    }

        //    return View(lista);
        //}


        public ActionResult Create()
        {
            ViewBag.IdTamano = new SelectList(db.C_Tamanos, "IdTamanos", "tamanos");
            ViewBag.IdTemperamento = new SelectList(db.C_Temperamentos, "IdTemperamentos", "temperamento");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdAnimal,IdTamano,IdTemperamento,nombre,especie,raza,sexo,fechaNacimiento,otrasSenas,padecimientos,ImagenURL")] C_Animales animales, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
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

                //C_Animales animales = this.Convertir(animalesViewModel);

                //using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
                //{
                //    unidad.genericDAL.Add(animales);
                //    unidad.Complete();

                db.C_Animales.Add(animales);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");



            }

            ViewBag.IdTamano = new SelectList(db.C_Tamanos, "IdTamanos", "tamanos", animales.IdTamano);
            ViewBag.IdTemperamento = new SelectList(db.C_Temperamentos, "IdTemperamentos", "temperamento", animales.IdTemperamento);
            return View(animales);


        }

        public async Task<ActionResult>Edit(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_Animales animales = await db.C_Animales.FindAsync(id);
            if (animales == null)
            {
                return HttpNotFound();
            }


            ViewBag.IdTamano = new SelectList(db.C_Tamanos, "IdTamanos", "tamanos", animales.IdTamano);
            ViewBag.IdTemperamento = new SelectList(db.C_Temperamentos, "IdTemperamentos", "temperamento", animales.IdTemperamento);
            return View(this.Convertir(animales));

            //C_Animales animales;

            //using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            //{
            //    animales = unidad.genericDAL.Get(id);

            //}

            //return View(this.Convertir(animales));
        }


        [HttpPost]
       public async Task<ActionResult> Edit([Bind(Include = "IdAnimal,IdTamano,IdTemperamento,nombre,especie,raza,sexo,fechaNacimiento,otrasSenas,padecimientos,ImagenURL")] C_Animales animales, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
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



                //using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
                //{
                //    unidad.genericDAL.Update(this.Convertir(animalesViewModel));
                //    unidad.Complete();
                //}

                db.Entry(animales).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdTamano = new SelectList(db.C_Tamanos, "IdTamanos", "tamanos", animales.IdTamano);
            ViewBag.IdTemperamento = new SelectList(db.C_Temperamentos, "IdTemperamentos", "temperamento", animales.IdTemperamento);
            return View(animales);
        }

        public ActionResult Details(int id)
        {

            C_Animales animales;
            using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                animales = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(animales));
        }


        public async Task<ActionResult>Delete(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_Animales animales = await db.C_Animales.FindAsync(id);
            if (animales == null)
            {
                return HttpNotFound();
            }
            return View(this.Convertir(animales));

            //C_Animales animales;
            //using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            //{
            //    animales = unidad.genericDAL.Get(id);

            //}

            //return View(this.Convertir(animales));
        }

        [HttpPost]
        public ActionResult Delete(C_AnimalesViewModel animalesViewModel)
        {
            using (UnidadDeTrabajo<C_Animales> unidad = new UnidadDeTrabajo<C_Animales>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(animalesViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



    }

}
