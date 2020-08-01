using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class CedulaDALImpl : ICedulaDAL
    {
        private BDContext context;
        public List<sp_ReporteAdopciones_Result> datosReporte(string Cedula)
        {
            List<sp_ReporteAdopciones_Result> resultado;

            using (context = new BDContext())
            {
                resultado = context.sp_ReporteAdopciones(Cedula).ToList();
            }

            return resultado;
        }
    }
}
