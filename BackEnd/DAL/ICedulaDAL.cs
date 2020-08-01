using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface ICedulaDAL
    {
        List<sp_ReporteAdopciones_Result> datosReporte(string Cedula);
    }
}
