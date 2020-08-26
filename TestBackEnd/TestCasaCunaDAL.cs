using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Linq.Expressions;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBackEnd
{
    [TestClass]
    public class TestCasaCunaDAL
    {
        private UnidadDeTrabajo<C_CasaCuna> unidad;

       // public UnidadDeTrabajo<C_CasaCuna> Unidad { get => unidad; set => unidad = value; }

        [TestMethod]
        public void TestAddGenerico()
        {

            C_CasaCuna casaCuna = new C_CasaCuna
            {
                
                Metros = "metros"
                

            };



            using (unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {
                unidad.genericDAL.Add(casaCuna);
                Assert.AreEqual(true, unidad.Complete());
            }

        }

        [TestMethod]
        public void TestGetByName()
        {

            using (unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {
                Expression<Func<C_CasaCuna, bool>> consulta = (c => c.Metros.Contains("a"));
                List<C_CasaCuna> lista = unidad.genericDAL.Find(consulta).ToList();

                Assert.AreEqual(true, unidad.Complete());
            }

        }

        [TestMethod]
        public void TestRemove()
        {

            C_CasaCuna casaCuna = new C_CasaCuna
            {

               IdCasaCuna = 7


            };



            using (unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {
                unidad.genericDAL.Remove(casaCuna);
                Assert.AreEqual(true, unidad.Complete());
            }

        }

        [TestMethod]
        public void TestUpdate()
        {

            C_CasaCuna casaCuna = new C_CasaCuna
            {

                IdCasaCuna =8, 
                IdPersona = 1,
                Metros = "350",
                PropiedadCercada =true, 
                OtrasMascotas = 3,
                CapacidadDisponible =5, 
                DescripcionPropiedad = "Color Naranja"
                


            };

            using (unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {
                unidad.genericDAL.Update(casaCuna);
                Assert.AreEqual(true, unidad.Complete());
            }

        }



    }
}
