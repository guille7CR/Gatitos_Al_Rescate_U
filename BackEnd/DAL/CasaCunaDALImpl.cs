using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BackEnd.DAL
{
    public class CasaCunaDALImpl : ICasaCunaDAL
    {
        private BDContext context;
        public List<sp_ReporteCasaCuna_Result> datosReporte(int ProvinciaId)
        {
            List<sp_ReporteCasaCuna_Result> resultado;

            using (context = new BDContext())
            {
                resultado = context.sp_ReporteCasaCuna(ProvinciaId).ToList();
            }

            return resultado;

        }

        public List<SelectListItem> getProvincias()
        {          

          
            using (UnidadDeTrabajo<C_Provincia> unidad = new UnidadDeTrabajo<C_Provincia>(new BDContext()))
            {

                List<SelectListItem> li = new List<SelectListItem>();
                 var listado = unidad.genericDAL.GetAll();



                foreach (var dato in listado)
                {
                    li.Add(new SelectListItem
                    {
                        Value = dato.IdProvincia.ToString(),
                        Text = dato.NombreProvincia
                    });
                };


                return li;


            }


        }




    }
}
