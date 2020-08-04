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
    public class TestCasaCunaDAL
    {
        private UnidadDeTrabajo<C_CasaCuna> unidad;


        [TestMethod]
        public void TestAddGenerico()
        {

            C_CasaCuna casaCuna = new C_CasaCuna
            {
                Metros = "metras"
            };



            using (unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {
                unidad.genericDAL.Add(casaCuna);
                Assert.AreEqual(true, unidad.Complete());
            }

        }

       
    }
}
