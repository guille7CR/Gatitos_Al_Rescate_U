using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestBackEnd
{
    [TestClass]
    public class TestUserDAL
    {
        private UnidadDeTrabajo<Users> unidad;


        [TestMethod]
        public void TestAdd()
        {

            Users usuarios = new Users
            {
                nombre = "Oscar"
            };



            using (unidad = new UnidadDeTrabajo<Users>(new BDContext()))
            {
                unidad.genericDAL.Add(usuarios);
                Assert.AreEqual(true, unidad.Complete());
            }

        }

        [TestMethod]
        public void TestGetByName()
        {

            using (unidad = new UnidadDeTrabajo<Users>(new BDContext()))
            {
                Expression<Func<Users, bool>> consulta = (c => c.nombre.Contains("O"));
                List<Users> lista = unidad.genericDAL.Find(consulta).ToList();

                Assert.AreEqual(true, unidad.Complete());
            }

        }

        [TestMethod]
        public void TestRemove()
        {

            Users users = new Users
            {

                UserId = 17


            };



            using (unidad = new UnidadDeTrabajo<Users>(new BDContext()))
            {
                unidad.genericDAL.Remove(users);
                Assert.AreEqual(true, unidad.Complete());
            }

        }


    }
}

