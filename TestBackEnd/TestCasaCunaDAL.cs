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

        public UnidadDeTrabajo<C_CasaCuna> Unidad { get => unidad; set => unidad = value; }

        [TestMethod]
        public void TestAddGenerico()
        {

            C_CasaCuna casaCuna = new C_CasaCuna
            {
                Metros = "metros"
            };



            using (Unidad = new UnidadDeTrabajo<C_CasaCuna>(new BDContext()))
            {
                Unidad.genericDAL.Add(casaCuna);
                Assert.AreEqual(true, Unidad.Complete());
            }

        }


    }
}
